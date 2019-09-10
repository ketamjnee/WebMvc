using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ShopOnlineSystem.Models.ModelData;
using System.IO;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace ShopOnlineSystem.Models.DAO
{
    public class UserDAO
    {
        static ShopOnlineEntities db = null;
        public UserDAO()
        {
            db = new ShopOnlineEntities();
        }
        public static bool checkMail(string emailWeb)
        {
            db = new ShopOnlineEntities();
            try
            {
                var a = db.WebUsers.Where(x => x.email == emailWeb).Count();
                if (a > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return false;
        }
        public static ModelView.UserView getUserId(int Id)
        {
            db = new ShopOnlineEntities();
            WebUser user1 = db.WebUsers.Find(Id) as WebUser;
            ModelView.UserView uv = new ModelView.UserView();
            try
            {
                uv.id = user1.ID;
                uv.name = user1.name;
                uv.uAddress = user1.uAddress;
                uv.email = user1.email;
                uv.pwd = user1.pwd;
                uv.repwd = user1.pwd;
                uv.phone = user1.phone;
                uv.zipcode = user1.zipcode;
                uv.username = user1.username;
                uv.avatar = user1.avatar;
                return uv;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return uv;
        }
        public static bool updateInfo(ModelView.UserView item)
        {
            db = new ShopOnlineEntities();
            
            try
            {
                WebUser user1 = db.WebUsers.Find(item.id) as WebUser;
                user1.name = item.name;
                user1.uAddress = item.uAddress;
                user1.pwd = item.pwd;
                user1.phone = item.phone;
                user1.zipcode = item.zipcode;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            
        }
        public static ModelView.UserView loginUser(ModelView.UserView item)
        {
            db = new ShopOnlineEntities();
            try
            {
                
                WebUser user = db.WebUsers.Where(x => x.email == item.email).FirstOrDefault() as WebUser;
                if (user.ID > 0)
                {
                    item.pwd = Decrypt(user.pwd);
                    item.id = user.ID;
                    item.userType = user.usertype;
                    item.name = user.name;
                    return item;
                }
            }
            catch (Exception ex)
            {
                return item;
                throw ex;
            }
            return item;
        }
        public static bool addUser(ModelView.UserView item)
        {
            db = new ShopOnlineEntities();
            try
            {
                WebUser user = new WebUser
                {
                    username = item.username,
                    email = item.email,
                    //Mã hóa
                    pwd = Encrypt(item.pwd),
                    name = item.name,
                    uAddress = item.uAddress,
                    phone = item.phone,
                    zipcode = item.zipcode
                };
                db.WebUsers.Add(user);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return false;
        }
        public static bool addFeedBack(ModelView.CommentView item)
        {
            db = new ShopOnlineEntities();
            try
            {
                Comment cm = new Comment
                {
                    feedback = item.comment,
                    email = item.email,
                    typeComment = 0,
                    typeFB = item.typeFB
                };
                db.Comments.Add(cm);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
        //VA co(de/py) cực mạnh
        #region Mã hóa pass
        // set permutations
        public const String strPermutation = "ouiveyxaqtd";
        public const Int32 bytePermutation1 = 0x19;
        public const Int32 bytePermutation2 = 0x59;
        public const Int32 bytePermutation3 = 0x17;
        public const Int32 bytePermutation4 = 0x41;
        // encoding
        public static string Encrypt(string strData)
        {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(strData)));           
        }
        // decoding
        public static string Decrypt(string strData)
        {
            return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(strData)));
        }
        // encrypt
        public static byte[] Encrypt(byte[] strData)
        {
            PasswordDeriveBytes passbytes =
            new PasswordDeriveBytes(strPermutation,
            new byte[] { bytePermutation1,
                         bytePermutation2,
                         bytePermutation3,
                         bytePermutation4
            });

            MemoryStream memstream = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = passbytes.GetBytes(aes.KeySize / 8);
            aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

            CryptoStream cryptostream = new CryptoStream(memstream,
            aes.CreateEncryptor(), CryptoStreamMode.Write);
            cryptostream.Write(strData, 0, strData.Length);
            cryptostream.Close();
            return memstream.ToArray();
        }

        // decrypt
        public static byte[] Decrypt(byte[] strData)
        {
            PasswordDeriveBytes passbytes =
            new PasswordDeriveBytes(strPermutation,
            new byte[] { bytePermutation1,
                         bytePermutation2,
                         bytePermutation3,
                         bytePermutation4
            });

            MemoryStream memstream = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = passbytes.GetBytes(aes.KeySize / 8);
            aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

            CryptoStream cryptostream = new CryptoStream(memstream,
            aes.CreateDecryptor(), CryptoStreamMode.Write);
            cryptostream.Write(strData, 0, strData.Length);
            cryptostream.Close();
            return memstream.ToArray();
        }
        #endregion
        #region Quên pass      
        public static void sendVerificationLinkEmail(string email, string emailFor = "ResetPassword")
        {
            var verifyUrl = "/User/" + emailFor;
            var link = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.PathAndQuery, verifyUrl);
            var fromEmail = new MailAddress("testkeylogger2019@gmail.com", "Nội thất Incom");
            var toEmail = new MailAddress(email);
            var fromEmailPass = "testkeylogger";
            string subject = "";
            string body = "";
            if(emailFor == "ResetPassword")
            {
                subject = "Lấy lại mật khẩu";
                body = "Chào bạn, </br> chúng tôi nhận được yêu cầu lấy lại mật khẩu. Vui lòng bấm vào link phía" +
                    " dưới để đặt lại mật khẩu </br><a href=" + link + ">Link đặt lại mật khẩu</a>";
            }
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPass)
            };
        }
        
    
        #endregion
    }
}