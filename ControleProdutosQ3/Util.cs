using ControleProdutosQ3.Models;

namespace ControleProdutosQ3
{
	public class Util
	{
		public static byte[] ReadFully2(string input)
		{
			FileStream sourceFile = new FileStream(input, FileMode.Open); //Open streamer
			BinaryReader binReader = new BinaryReader(sourceFile);
			byte[] output = new byte[sourceFile.Length]; //create byte array of size file
			for (long i = 0; i < sourceFile.Length; i++)
				output[i] = binReader.ReadByte(); //read until done
			sourceFile.Close(); //dispose streamer
			binReader.Close(); //dispose reader
			return output;
		}

		public static byte[] SalvaImagem(IFormFile imagem,  string wwwrootPath) 
		{
			string caminho = Path.Combine(wwwrootPath, "Uploads");
            string nomeArquivo = Path.GetFileName(imagem!.FileName);

            if (!Directory.Exists(caminho))
            {
                Directory.CreateDirectory(caminho);
            }

            using (FileStream fileStream = new FileStream(Path.Combine(caminho, nomeArquivo), FileMode.Create))
            {
                imagem.CopyTo(fileStream);
            }

			return ReadFully2(Path.Combine(caminho, nomeArquivo));

        }
		

		internal static byte[]? ReadFully2(Func<string?> toString)
		{
			throw new NotImplementedException();
		}

		public static String Criptografia(String _senha)
		{
			var senhaEncriptada = "";

			byte[] salt = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

			EncryptDecrypt enc = new EncryptDecrypt(salt);

			senhaEncriptada = enc.Encrypt(_senha);

			return senhaEncriptada;
		}

		public static Boolean Decriptografia(string senhaBanco, string _senha)
		{
			byte[] salt = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

			EncryptDecrypt enc = new EncryptDecrypt(salt);

			var senhaDecriptada = enc.Decrypt(senhaBanco);

			if (senhaDecriptada.Equals(_senha))
			{
				return true;
			}

			return false;
		}

	}
}
