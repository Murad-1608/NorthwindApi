using Core.Entity.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Mal əlavə olundu";
        internal static string MaintenanceTime = "Baxım vaxtıdır";
        internal static string ProductsListed = "Mallar gətirildi";
        public static string ProductCountOfCategoryError = "Eyni kateqoriyada en cox 10 mehsul ola biler";
        public static string ProductUpdated = "Mehsul yenilendi";
        public static string ProdutNameAlreadyExist = "Bu adda mehsul movcuddur";

        public static string CategoryCountError = "Kateqoriya sayi 15 olduqda sisteme yeni mehsul elave etmek olmaz";

        public static string AuthorizationDenied = "Selahiyyetiniz yoxdur.";

        public static string UserRegistered = "Qeydiyyat ugurla yekunlasdi";
        public static User UserNotFound = new User();
        public static User PasswordError=new User();
        public static string SuccessfulLogin = "Ugurlu giris";
        public static string UserAlreadyExists = "Bele bir istifade movcuddur";
        public static string AccessTokenCreated = "Token yaradildi";
    }
}
