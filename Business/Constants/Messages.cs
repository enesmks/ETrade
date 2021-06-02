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
        public static string CompanyNameCanNotBeEmpty;
        public static string CityCanNotBeEmpty="Şehir boş bırakılamaz";
        public static string CategoryCanNotBeEmpty="Kaetgori boş bırakılamaz";
        public static string AddressCanNotBeEmpty="Adres boş bırakılamaz";
        public static string CountryCanNotBeEmpty="Ülke boş bırakılamaz";
        public static string ErrorOfCompanyNameLength="Şirket adı 2 ile 50 karakter arasında olmalıdır";
        public static string ErrorOfAdressLength="Adres uzunluğu 10-100 karakter aresında olmalıdır";
        public static string ErrorOfCityLength = "Şehir ismi uzunluğu 2-20 karakter aresında olmalıdır";
        public static string ErrorOfCountryLength = "Ülke ismi uzunluğu 2-20 karakter aresında olmalıdır";
        public static string ErrorOfPhoneLength="Yanış telefon uzunlunğu";
        public static string PhoneCanNotBeEmpty="Telefon bilgisi boş bırakılamaz";
        public static string BirthdayCanNotBeEmpty = "Doğum günü bilgisi boş bırakılamaz";
        public static string FirstNameCanNotBeEmpty = "İsim bilgisi boş bırakılamaz";
        public static string HireDateCanNotBeEmpty = "İşe alım tarihi boş bırakılamaz";
        public static string LastNameCanNotBeEmpty = "Soyisim bilgisi boş bırakılamaz";
        public static string PostalCodeCanNotBeEmpty = "Posta kodu bilgisi boş bırakılamaz";
        public static string ErrorOfFirstNameLength = "İsim  2-20 karakter arasında olmalıdır";
        public static string ErrorOfLastNameLength = "Soyisim  2-20 karakter arasında olmalıdır";
        public static string ErrorOfPostalCodeLength = "Hatalı posta kodu";
        public static string WrongHireDate="Hatalı işe alım tarihi";
        public static string WrongBirthDate = "Hatalı doğum tarihi";
        public static string ShipCityCanNotBeEmpty = "Sipariş yapılacak şehir boş bırakılamaz";
        public static string ShipCountryCanNotBeEmpty = "Sipariş yapılcak ülke boş bırakılamaz";
        public static string ShipAddressCanNotBeEmpty = "Sipariş adresi boş bırakılamaz";
        public static string OrderDateCanNotBeEmpty = "Sipariş tarihi boş bırakılamaz";
        public static string WrongArrivalDate="Hatalı teslim tarihi";
        public static string OrderLimitExceeded="Sipariş sınırı aşıldı";
        public static string EmptyOrderList="Siparişler boş";     
        public static string UpdatebleNonExistingOrder="Güncellenebilir sipariş bulunmamaktadır";
        public static string DeletebleNonExistingOrder = "Silinebilir sipariş bulunmamaktadır";
        public static string UpdatebleNonExistingProduct = "Güncellenebilir ütün bulunmamaktadır";
        public static string DeletebleNonExistingProduct = "Silinebilir ürün bulunmamaktadır";
        public static string ProductNameCanNotBeEmpty="Ürün ismi boş bırakılamaz";
        public static string UnitPriceCanNotBeEmpty = "Ürün fiyatı boş bırakılamaz";
        public static string UnitsInStockCanNotBeEmpty = "Stok adedi boş bırakılamaz";
        public static string QuantityPerUnitCanNotBeEmpty = "Birim miktarı boş bırakılamaz";
        public static string ErrorOfProductNameLength="Ürün ismi 2-50 karakter arasında olabilir";
        public static string WrongUnitPrice="Hatalı birim fiyatı";
        public static string ErrorOfEmailLength= "Eposta adresi 2-50 karakter arasında olabilir";
        public static string PasswordCanNotBeEmpty = "Şifre  boş bırakılamaz";
        public static string ErrorOfPasswordlLength="Şifre en az 6 en çok 50 karakter olabilir";
        public static string PasswordMustContainUppercase="Şifre büyük harf içermelidir";
        public static string PasswordMustContainLowercase = "Şifre küçük harf içermelidir";
        public static string PasswordMustContainNumber = "Şifre rakam içermelidir";
        public static string NeedValidEmailAddress="Geçerli bir eposta adresi giriniz";
    }
}
