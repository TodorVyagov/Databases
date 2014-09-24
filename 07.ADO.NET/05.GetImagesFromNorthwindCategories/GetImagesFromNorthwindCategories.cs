namespace GetImagesFromNorthwindCategories
{
    using System;
    using System.Data.SqlClient;
    using System.IO;

    class GetImagesFromNorthwindCategories
    {
        static void Main()
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=true");
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand cmd = new SqlCommand("SELECT CategoryName, Picture FROM Categories", dbCon);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string name = reader["CategoryName"].ToString().Replace('/', '_');
                    byte[] imageArray = (byte[])reader["Picture"];
                    string imagePath = "..\\..\\" + name + ".JPG";

                    byte[] imageData = SkipImageMetadata(imageArray);
                    SaveImageToFile(imagePath, imageData);
                }
            }
        }

        private static byte[] SkipImageMetadata(byte[] imageRawData)
        {
            int len = imageRawData.Length;
            int header = 78;
            byte[] imageData = new byte[len - header];
            Array.Copy(imageRawData, header, imageData, 0, len - header);
            return imageData;
        }

        private static void SaveImageToFile(string imagePath, byte[] imageData)
        {
            using (FileStream imageFile = new FileStream(imagePath, FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter sr = new BinaryWriter(imageFile))
                {
                    sr.Write(imageData);
                }
            }
        }
    }
}
