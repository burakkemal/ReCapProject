using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string updatedRental = "Kiralama Güncellendi";
        public static string deletedRental = "Kiralama Silindi";
        public static string updatedCustomer = "Müşteri Güncellendi";
        public static string deletedCustomer = "Müşteri Silindi";
        public static string deletedUser = "Kullanıcı Silindi";
        public static string updatedUser = "Kullanıcılar Güncellendi";
        public static string Added = "Eklendi";
        public static string CarNameInvalid = "İsim geçersiz";
        public static string Listed = "Listelendi";
        public static string MaintenanceTime = "bakımda";
        public static string updatedCar = "araba güncellendi";
        public static string NotRentable = "Araba kiralanamaz";
        public static string RentadMessage = "Kiralandı";
        public static string CarImageLimitExceeded = "Max resim sayısına ulaşıldı";
        public static string CarImageCarIdInvalid = "Araba id'si girilmedi";
        public static string CarImageDeleted = "Araba resmi silindi";
        public static string InvalidImagetype = "resim tipi geçersiz";
        public static string CarImageUpdated = "Araba resmi güncellendi";
        public static string UpdatedCarImage = "Resim Güncelendi";
        public static string ErrorUpdateCarImage = "Güncelleme başarısız";
        public static string AuthorizationDenied = "Yetkiniz Yok.";
        public static string ClaimsListed="Claimler listelendi";
        internal static string UserRegistered="Kayıt oldu";
        public static string UserNotFound="Kullanıcı bulunamadı";
        internal static string PasswordError="Şifre hatası";
        internal static string SuccessfulLogin="başarılı giriş";
        internal static string UserAlreadyExists= "Kullanıcı zaten var";
        internal static string AccessTokenCreated="Token oluşturuldu";
        public static string GetErrorCarMessage;
        public static string GetSuccessCarMessage;
        public static string succeed ="Başarılı";
        public static string CustomersListed="Müşteriler listelendi";
    }
}
