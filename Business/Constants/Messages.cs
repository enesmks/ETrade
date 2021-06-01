using Core.Entitites.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string TokenCreated="Token oluşturuldu";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string PasswordError="Hatalı şifre";
        public static string SuccessfulLogin="Giriş başarılı";
        public static string Registered="Kayıt olundu";
        public static string UserAlreadyExists="Kullanıcı zaten var";
        public static string Added="Başarıyla eklendi";
        public static string Deleted="Başarıyla silindi";
        public static string Updated="Başarıyla güncellendi";
        public static string ProductLimitExceeded="Bir kullanıcı en fazla 15 ürün eklyebilir";
        public static string ProductCountOfCategoryError="Bir kategoriye en fazal 10 ürün ekleyebilirsiniz";
        public static string AuthorizationDenied="Yetkisiz  giriş";
    }
}
