using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace AspGraduateProjAdminPan.BL.Helper
{
    public static class UploadFileHelper
    {
        public static string SaveFile(IFormFile file,string FolderPath)
        {


            string filepath = Directory.GetCurrentDirectory() +"/wwwroot/Files/"+ FolderPath+"/";
            //merg it with the file name
            //Path.GetFile Name if FileName is full path " because of some browsers "
            //i used GUID to solve problems if two file have the same name.

            string FileName = Guid.NewGuid() + Path.GetFileName(file.FileName);
            //add '/' character path parts if not exists
            string FileFullPath = Path.Combine(filepath + FileName);

            ///final step save file to server as stream "data overTime" and  database
            ///here using statement to dispose resource from memory
            using (var StreamOfData = new FileStream(FileFullPath, FileMode.Create))
            {
                file.CopyTo(StreamOfData);
            }


            return  FileName;



        }

        public static void RemoveFile(string FileName,string FilePath)
        {
              if (File.Exists(Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FilePath+"/"+FileName))
            {
                File.Delete(Directory.GetCurrentDirectory() + "/wwwroot/Files/"+ FilePath + "/" + FileName);
            }
        }
    }
}
