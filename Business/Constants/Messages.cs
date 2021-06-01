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
        public static string ErrorOfAdressLength;
        public static string ErrorOfCityLength;
        public static string ErrorOfCountryLength;
        public static string ErrorOfPhoneLength;
        public static string PhoneCanNotBeEmpty;
        public static string BirthdayCanNotBeEmpty;
        public static string FirstNameCanNotBeEmpty;
        public static string HireDateCanNotBeEmpty;
        public static string LastNameCanNotBeEmpty;
        public static string PostalCodeCanNotBeEmpty;
        public static string ErrorOfFirstNameLength;
        public static string ErrorOfLastNameLength;
        public static string ErrorOfPostalCodeLength;
        public static string WrongHireDate;
        public static string WrongBirthDate;
        public static string ShipCityCanNotBeEmpty;
        public static string ShipCountryCanNotBeEmpty;
        public static string ShipAddressCanNotBeEmpty;
        public static string OrderDateCanNotBeEmpty;
        public static string ShipAddressNotBeEmpty;
        public static string WrongArrivalDate;
        public static string OrderLimitExceeded;
        public static string EmptyOrderList;     
        public static string UpdatebleNonExistingOrder;
        public static string DeletebleNonExistingOrder;
        public static string UpdatebleNonExistingProduct;
        public static string DeletebleNonExistingProduct;
        public static string ProductNameCanNotBeEmpty;
        public static string UnitPriceCanNotBeEmpty;
        public static string UnitsInStockCanNotBeEmpty;
        public static string QuantityPerUnitCanNotBeEmpty;
        public static string ErrorOfProductNameLength;
        public static string WrongUnitPrice;
        public static string ErrorOfEmailLength;
        public static string PasswordCanNotBeEmpty;
        public static string ErrorOfPasswordlLength;
    }
}
