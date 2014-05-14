using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FtpLib;
using System.IO;
using System.Net;
using System.Globalization;
using System.Threading;

struct FilePara
{
    public string FileName;
    public long FileSize;
    public string CurrentDirectory;
    public string Ftp_sc;
    public string Ftp_kf;
    public string Port_sc;
    public string Port_kf;
    public string User_sc;
    public string User_kf;
    public string Passwd_sc;
    public string Passwd_kf;
}

namespace FTPExchange
{
    public partial class FTPExchange : Form
    {
        private delegate void CheckSize(long orgFilesize,long iFilesize);
        private delegate void ChangeText(string Labeltext);
        Thread TCheckLocalSize, TCheckFtpSize, TFileDown, TFileUpload;

        private void prcBarValue(long orgFilesize,long iFilesize)
        {
            if (prcBar.InvokeRequired)
            {
                CheckSize _filesize = new CheckSize(prcBarValue);
                this.Invoke(_filesize, new object[] { orgFilesize, iFilesize });
            }
            else
            {
                prcBar.Maximum = (int)orgFilesize;
                prcBar.Value = (int)iFilesize;
                label10.BackColor = Color.Transparent;
                label10.Text = "传输中..."+(int)(iFilesize * 100 / orgFilesize) + "%";
            }
        }

        private void labeltext(string Labeltext)
        {
            if (label10.InvokeRequired)
            {
                ChangeText _labeltext = new ChangeText(labeltext);
                this.Invoke(_labeltext, new object[] { Labeltext });
            }
            else
            {
                label10.Text = Labeltext;
            }
        }

        private void CheckLocalSize(object FileP)
        {
            long filesize=0;
            FilePara oFile = (FilePara)FileP;
            prcBarValue(oFile.FileSize, 0);
            while (TFileDown.IsAlive == true)
            {
                if (File.Exists(oFile.CurrentDirectory + "\\" + oFile.FileName))
                {
                    FileInfo fi = new FileInfo(oFile.CurrentDirectory + "\\" + oFile.FileName);
                    filesize = fi.Length;
                }
                
                prcBarValue( oFile.FileSize,filesize );
                Thread.Sleep(1000);
            }
        }

        private void CheckFtpSize(object FileP)
        {
            long filesize = 0;
            long ftpsize = 0;

            FilePara oFile = (FilePara)FileP;
            FtpWeb FTP_kf = new FtpWeb(oFile.Ftp_kf, "", oFile.User_kf, oFile.Passwd_kf);
            FtpWeb FTP_sc = new FtpWeb(oFile.Ftp_sc, "", oFile.User_sc, oFile.Passwd_sc);

            prcBarValue(oFile.FileSize*2, 0);
            while (TFileUpload.IsAlive == true)
            {
                if (radioButton_sc2kf.Checked == true)
                {
                    ftpsize = FTP_kf.GetFileSize(oFile.FileName);
                }
                else if (radioButton_kf2sc.Checked == true)
                {
                    ftpsize = FTP_sc.GetFileSize(oFile.FileName);
                }
                if (File.Exists(oFile.CurrentDirectory + "\\" + oFile.FileName))
                {
                    FileInfo fi = new FileInfo(oFile.CurrentDirectory + "\\" + oFile.FileName);
                    filesize = fi.Length;
                }

                prcBarValue(oFile.FileSize * 2, filesize+ftpsize);
                Thread.Sleep(1000);
            }
        }

        private void kf2local(object FileP)
        {
            FilePara oFile = (FilePara)FileP;
            FtpWeb FTP_kf = new FtpWeb(oFile.Ftp_kf, "", oFile.User_kf, oFile.Passwd_kf);
            FtpWeb FTP_sc = new FtpWeb(oFile.Ftp_sc, "", oFile.User_sc, oFile.Passwd_sc);

            if (FTP_kf.FileExist(oFile.FileName) == false)
            {
                MessageBox.Show("文件不存在，请核实!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button2_Click(this, null);
            }

            FTP_kf.Download( oFile.CurrentDirectory, oFile.FileName);

            FileInfo fi = new FileInfo(oFile.CurrentDirectory + "\\" + oFile.FileName);
            long filesize = fi.Length;
            labeltext("传输成功");

            OpenFolderAndSelectFile( oFile.CurrentDirectory + "\\" + oFile.FileName);
        }

        private void sc2local(object FileP)
        {
            FilePara oFile = (FilePara)FileP;
            FtpWeb FTP_kf = new FtpWeb(oFile.Ftp_kf, "", oFile.User_kf, oFile.Passwd_kf);
            FtpWeb FTP_sc = new FtpWeb(oFile.Ftp_sc, "", oFile.User_sc, oFile.Passwd_sc);

            if (FTP_kf.FileExist(oFile.FileName) == false)
            {
                MessageBox.Show("文件不存在，请核实!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button2_Click( this, null);
            }

            FTP_kf.Download(oFile.CurrentDirectory, oFile.FileName);

            FileInfo fi = new FileInfo(oFile.CurrentDirectory + "\\" + oFile.FileName);
            long filesize = fi.Length;
            labeltext("传输成功");

            OpenFolderAndSelectFile(oFile.CurrentDirectory + "\\" + oFile.FileName);
        }

        private void sc2kf(object FileP)
        {
            FilePara oFile = (FilePara)FileP;
            FtpWeb FTP_kf = new FtpWeb(oFile.Ftp_kf, "", oFile.User_kf, oFile.Passwd_kf);
            FtpWeb FTP_sc = new FtpWeb(oFile.Ftp_sc, "", oFile.User_sc, oFile.Passwd_sc);

            if (FTP_sc.FileExist(oFile.FileName) == false)
            {
                MessageBox.Show("文件不存在，请核实!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button2_Click(this, null);
            }

            FTP_sc.Download(oFile.CurrentDirectory, oFile.FileName);
            FTP_kf.Upload( oFile.FileName );

            FileInfo fi = new FileInfo(oFile.CurrentDirectory + "\\" + oFile.FileName);
            long filesize = fi.Length;

            File.Delete(oFile.CurrentDirectory + "\\" + oFile.FileName);
            labeltext("传输成功");
        }

        private void kf2sc(object FileP)
        {
            FilePara oFile = (FilePara)FileP;
            FtpWeb FTP_kf = new FtpWeb(oFile.Ftp_kf, "", oFile.User_kf, oFile.Passwd_kf);
            FtpWeb FTP_sc = new FtpWeb(oFile.Ftp_sc, "", oFile.User_sc, oFile.Passwd_sc);

            if (FTP_kf.FileExist(oFile.FileName) == false)
            {
                MessageBox.Show("文件不存在，请核实!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button2_Click(this, null);
            }

            FTP_kf.Download(oFile.CurrentDirectory, oFile.FileName);
            FTP_sc.Upload(oFile.FileName);

            FileInfo fi = new FileInfo(oFile.CurrentDirectory + "\\" + oFile.FileName);
            long filesize = fi.Length;

            File.Delete(oFile.CurrentDirectory + "\\" + oFile.FileName);
            labeltext("传输成功");
        }

        public FTPExchange()
        {
            InitializeComponent();
            //this.label10.Parent = this.prcBar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FilePara oFile = new FilePara();

            oFile.FileName = filename.Text.ToString();
            oFile.Ftp_sc = ftp_sc.Text.ToString();
            oFile.Ftp_kf = ftp_kf.Text.ToString();
            oFile.Port_sc = port_sc.Text.ToString();
            oFile.Port_kf = port_kf.Text.ToString();
            oFile.User_sc = user_sc.Text.ToString();
            oFile.User_kf = user_kf.Text.ToString();
            oFile.Passwd_sc = passwd_sc.Text.ToString();
            oFile.Passwd_kf = passwd_kf.Text.ToString();
            oFile.CurrentDirectory = Environment.CurrentDirectory;

            FtpWeb FTP_kf = new FtpWeb(oFile.Ftp_kf, "", oFile.User_kf, oFile.Passwd_kf);
            FtpWeb FTP_sc = new FtpWeb(oFile.Ftp_sc, "", oFile.User_sc, oFile.Passwd_sc);

            if ( radioButton_kf2sc.Checked == true ) //开发到生产
            {
                if (FTP_kf.FileExist(oFile.FileName) == false)
                {
                    MessageBox.Show("文件不存在，请核实!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                oFile.FileSize = FTP_kf.GetFileSize(oFile.FileName);

                TCheckFtpSize = new Thread(new ParameterizedThreadStart(CheckFtpSize));
                TFileUpload = new Thread(new ParameterizedThreadStart(kf2sc));

                TFileUpload.Start(oFile);
                TCheckFtpSize.Start(oFile);
            }
            else if ( radioButton_sc2kf.Checked == true ) //生产到开发
            {
                if (FTP_sc.FileExist(oFile.FileName) == false)
                {
                    MessageBox.Show("文件不存在，请核实!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                oFile.FileSize = FTP_sc.GetFileSize(oFile.FileName);

                TCheckFtpSize = new Thread(new ParameterizedThreadStart(CheckFtpSize));
                TFileUpload = new Thread(new ParameterizedThreadStart(sc2kf));

                TFileUpload.Start(oFile);
                TCheckFtpSize.Start(oFile);
            }
            else if (radioButton_kf2loc.Checked == true) //开发到本地
            {
                if (FTP_kf.FileExist(oFile.FileName) == false)
                {
                    MessageBox.Show("文件不存在，请核实!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                oFile.FileSize = FTP_kf.GetFileSize(oFile.FileName);

                TCheckLocalSize = new Thread(new ParameterizedThreadStart(CheckLocalSize));
                TFileDown = new Thread(new ParameterizedThreadStart(kf2local));

                TFileDown.Start(oFile);
                TCheckLocalSize.Start(oFile);
            }
            else if (radioButton_sc2loc.Checked == true) //生产到本地
            {
                if(FTP_sc.FileExist(oFile.FileName) == false)
                {
                    MessageBox.Show("文件不存在，请核实!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                oFile.FileSize = FTP_sc.GetFileSize(oFile.FileName);

                TCheckLocalSize = new Thread(new ParameterizedThreadStart(CheckLocalSize));
                TFileDown = new Thread(new ParameterizedThreadStart(sc2local));

                TFileDown.Start(oFile);
                TCheckLocalSize.Start(oFile);
            }

        }

        private void OpenFolderAndSelectFile(String fileFullName)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + fileFullName;
            System.Diagnostics.Process.Start(psi);
        }

        private void FTPExchange_Shown(object sender, EventArgs e)
        {
            filename.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TCheckLocalSize != null && TCheckLocalSize.IsAlive)
            {
                TCheckLocalSize.Abort();
            }
            if (TCheckFtpSize != null && TCheckFtpSize.IsAlive)
            {
                TCheckFtpSize.Abort();
            }
            if (TFileDown!=null && TFileDown.IsAlive)
            {
                TFileDown.Abort();
            }
            if (TFileUpload!= null && TFileUpload.IsAlive)
            {
                TFileUpload.Abort();
            }
            labeltext("用户取消");
        }

    }
}

namespace FtpLib
{

    public class FtpWeb
    {
        string ftpServerIP;
        string ftpRemotePath;
        string ftpUserID;
        string ftpPassword;
        string ftpURI;

        /// <summary>
        /// 连接FTP
        /// </summary>
        /// <param name="FtpServerIP">FTP连接地址</param>
        /// <param name="FtpRemotePath">指定FTP连接成功后的当前目录, 如果不指定即默认为根目录</param>
        /// <param name="FtpUserID">用户名</param>
        /// <param name="FtpPassword">密码</param>
        public FtpWeb(string FtpServerIP, string FtpRemotePath, string FtpUserID, string FtpPassword)
        {
            ftpServerIP = FtpServerIP;
            ftpRemotePath = FtpRemotePath;
            ftpUserID = FtpUserID;
            ftpPassword = FtpPassword;
            ftpURI = "ftp://" + ftpServerIP + "/" + ftpRemotePath + "/";
        }

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="filename"></param>
        public void Upload(string filename)
        {
            FileInfo fileInf = new FileInfo(filename);
            string uri = ftpURI + fileInf.Name;
            FtpWebRequest reqFTP;

            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.UseBinary = true;
            reqFTP.ContentLength = fileInf.Length;
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            FileStream fs = fileInf.OpenRead();
            try
            {
                Stream strm = reqFTP.GetRequestStream();
                contentLen = fs.Read(buff, 0, buffLength);
                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                strm.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                Insert_Standard_ErrorLog.Insert("FtpWeb", "Upload Error --> " + ex.Message);
            }
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        public void Download( string filePath, string fileName)
        {
            FtpWebRequest reqFTP;
            try
            {
                FileStream outputStream = new FileStream(filePath + "\\" + fileName, FileMode.Create);

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + fileName));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();
                outputStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                Insert_Standard_ErrorLog.Insert("FtpWeb", "Download Error --> " + ex.Message);
            }
        }


        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileName"></param>
        public void Delete(string fileName)
        {
            try
            {
                string uri = ftpURI + fileName;
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;

                string result = String.Empty;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                long size = response.ContentLength;
                Stream datastream = response.GetResponseStream();
                StreamReader sr = new StreamReader(datastream);
                result = sr.ReadToEnd();
                sr.Close();
                datastream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                Insert_Standard_ErrorLog.Insert("FtpWeb", "Delete Error --> " + ex.Message + "  文件名:" + fileName);
            }
        }

        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="folderName"></param>
        public void RemoveDirectory(string folderName)
        {
            try
            {
                string uri = ftpURI + folderName;
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.RemoveDirectory;

                string result = String.Empty;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                long size = response.ContentLength;
                Stream datastream = response.GetResponseStream();
                StreamReader sr = new StreamReader(datastream);
                result = sr.ReadToEnd();
                sr.Close();
                datastream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                Insert_Standard_ErrorLog.Insert("FtpWeb", "Delete Error --> " + ex.Message + "  文件名:" + folderName);
            }
        }

        /// <summary>
        /// 获取当前目录下明细(包含文件和文件夹)
        /// </summary>
        /// <returns></returns>
        public string[] GetFilesDetailList()
        {
            string[] downloadFiles;
            try
            {
                StringBuilder result = new StringBuilder();
                FtpWebRequest ftp;
                ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI));
                ftp.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                WebResponse response = ftp.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);

                //while (reader.Read() > 0)
                //{

                //}
                string line = reader.ReadLine();
                //line = reader.ReadLine();
                //line = reader.ReadLine();

                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf("\n"), 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                downloadFiles = null;
                Insert_Standard_ErrorLog.Insert("FtpWeb", "GetFilesDetailList Error --> " + ex.Message);
                return downloadFiles;
            }
        }

        /// <summary>
        /// 获取当前目录下文件列表(仅文件)
        /// </summary>
        /// <returns></returns>
        public string[] GetFileList(string mask)
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);

                string line = reader.ReadLine();
                while (line != null)
                {
                    if (mask.Trim() != string.Empty && mask.Trim() != "*.*")
                    {

                        string mask_ = mask.Substring(0, mask.IndexOf("*"));
                        if (line.Substring(0, mask_.Length) == mask_)
                        {
                            result.Append(line);
                            result.Append("\n");
                        }
                    }
                    else
                    {
                        result.Append(line);
                        result.Append("\n");
                    }
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                downloadFiles = null;
                if (ex.Message.Trim() != "远程服务器返回错误: (550) 文件不可用(例如，未找到文件，无法访问文件)。")
                {
                    Insert_Standard_ErrorLog.Insert("FtpWeb", "GetFileList Error --> " + ex.Message.ToString());
                }
                return downloadFiles;
            }
        }

        /// <summary>
        /// 获取当前目录下所有的文件夹列表(仅文件夹)
        /// </summary>
        /// <returns></returns>
        public string[] GetDirectoryList()
        {
            string[] drectory = GetFilesDetailList();
            string m = string.Empty;
            foreach (string str in drectory)
            {
                int dirPos = str.IndexOf("<DIR>");
                if (dirPos > 0)
                {
                    /*判断 Windows 风格*/
                    m += str.Substring(dirPos + 5).Trim() + "\n";
                }
                else if (str.Trim().Substring(0, 1).ToUpper() == "D")
                {
                    /*判断 Unix 风格*/
                    string dir = str.Substring(54).Trim();
                    if (dir != "." && dir != "..")
                    {
                        m += dir + "\n";
                    }
                }
            }

            char[] n = new char[] { '\n' };
            return m.Split(n);
        }

        /// <summary>
        /// 判断当前目录下指定的子目录是否存在
        /// </summary>
        /// <param name="RemoteDirectoryName">指定的目录名</param>
        public bool DirectoryExist(string RemoteDirectoryName)
        {
            string[] dirList = GetDirectoryList();
            foreach (string str in dirList)
            {
                if (str.Trim() == RemoteDirectoryName.Trim())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断当前目录下指定的文件是否存在
        /// </summary>
        /// <param name="RemoteFileName">远程文件名</param>
        public bool FileExist(string RemoteFileName)
        {
            string[] fileList = GetFileList("*.*");
            foreach (string str in fileList)
            {
                if (str.Trim() == RemoteFileName.Trim())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="dirName"></param>
        public void MakeDir(string dirName)
        {
            FtpWebRequest reqFTP;
            try
            {
                // dirName = name of the directory to create.
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + dirName));
                reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                Insert_Standard_ErrorLog.Insert("FtpWeb", "MakeDir Error --> " + ex.Message);
            }
        }

        /// <summary>
        /// 获取指定文件大小
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public long GetFileSize(string filename)
        {
            FtpWebRequest reqFTP;
            long fileSize = 0;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + filename));
                reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                fileSize = response.ContentLength;

                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                Insert_Standard_ErrorLog.Insert("FtpWeb", "GetFileSize Error --> " + ex.Message);
            }
            return fileSize;
        }

        /// <summary>
        /// 改名
        /// </summary>
        /// <param name="currentFilename"></param>
        /// <param name="newFilename"></param>
        public void ReName(string currentFilename, string newFilename)
        {
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + currentFilename));
                reqFTP.Method = WebRequestMethods.Ftp.Rename;
                reqFTP.RenameTo = newFilename;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                Insert_Standard_ErrorLog.Insert("FtpWeb", "ReName Error --> " + ex.Message);
            }
        }

        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="currentFilename"></param>
        /// <param name="newFilename"></param>
        public void MovieFile(string currentFilename, string newDirectory)
        {
            ReName(currentFilename, newDirectory);
        }

        /// <summary>
        /// 切换当前目录
        /// </summary>
        /// <param name="DirectoryName"></param>
        /// <param name="IsRoot">true 绝对路径   false 相对路径</param>
        public void GotoDirectory(string DirectoryName, bool IsRoot)
        {
            if (IsRoot)
            {
                ftpRemotePath = DirectoryName;
            }
            else
            {
                ftpRemotePath += DirectoryName + "/";
            }
            ftpURI = "ftp://" + ftpServerIP + "/" + ftpRemotePath + "/";
        }

        /// <summary>
        /// 删除订单目录Insert
        /// </summary>
        /// <param name="ftpServerIP">FTP 主机地址</param>
        /// <param name="folderToDelete">FTP 用户名</param>
        /// <param name="ftpUserID">FTP 用户名</param>
        /// <param name="ftpPassword">FTP 密码</param>
        public static void DeleteOrderDirectory(string ftpServerIP, string folderToDelete, string ftpUserID, string ftpPassword)
        {
            try
            {
                if (!string.IsNullOrEmpty(ftpServerIP) && !string.IsNullOrEmpty(folderToDelete) && !string.IsNullOrEmpty(ftpUserID) && !string.IsNullOrEmpty(ftpPassword))
                {
                    FtpWeb fw = new FtpWeb(ftpServerIP, folderToDelete, ftpUserID, ftpPassword);
                    //进入订单目录
                    fw.GotoDirectory(folderToDelete, true);
                    //获取规格目录
                    string[] folders = fw.GetDirectoryList();
                    foreach (string folder in folders)
                    {
                        if (!string.IsNullOrEmpty(folder) || folder != "")
                        {
                            //进入订单目录
                            string subFolder = folderToDelete + "/" + folder;
                            fw.GotoDirectory(subFolder, true);
                            //获取文件列表
                            string[] files = fw.GetFileList("*.*");
                            if (files != null)
                            {
                                //删除文件
                                foreach (string file in files)
                                {
                                    fw.Delete(file);
                                }
                            }
                            //删除冲印规格文件夹
                            fw.GotoDirectory(folderToDelete, true);
                            fw.RemoveDirectory(folder);
                        }
                    }

                    //删除订单文件夹
                    string parentFolder = folderToDelete.Remove(folderToDelete.LastIndexOf('/'));
                    string orderFolder = folderToDelete.Substring(folderToDelete.LastIndexOf('/') + 1);
                    fw.GotoDirectory(parentFolder, true);
                    fw.RemoveDirectory(orderFolder);
                }
                else
                {
                    throw new Exception("FTP 及路径不能为空！");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("删除订单时发生错误，错误信息为：" + ex.Message);
            }
        }
    }


    public class Insert_Standard_ErrorLog
    {
        public static void Insert(string x, string y)
        {

        }
    }


}