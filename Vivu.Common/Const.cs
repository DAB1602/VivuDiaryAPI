namespace Vivu.Common
{
    public class Const
    {

        #region Error Codes

        public static int ERROR_EXCEPTION = -4;

        #endregion

        #region Success Codes

        public static int SUCCESS_CREATE_CODE = 1;
        public static string SUCCESS_CREATE_MSG = "Save data success";
        public static int SUCCESS_READ_CODE = 1;
        public static string SUCCESS_READ_MSG = "Get data success";
        public static int SUCCESS_UPDATE_CODE = 1;
        public static string SUCCESS_UPDATE_MSG = "Update data success";
        public static int SUCCESS_DELETE_CODE = 1;
        public static string SUCCESS_DELETE_MSG = "Delete data success";
        public static int SUCCESS_LOGIN_CODE = 1;
        public static string SUCCESS_LOGIN_MSG = "Login success";


        #endregion

        #region Fail code

        public static int FAIL_CREATE_CODE = -1;
        public static string FAIL_CREATE_MSG = "Save data fail";
        public static int FAIL_READ_CODE = -1;
        public static string FAIL_READ_MSG = "Get data fail";
        public static int FAIL_UPDATE_CODE = -1;
        public static string FAIL_UPDATE_MSG = "Update data fail";
        public static int FAIL_DELETE_CODE = -1;
        public static string FAIL_DELETE_MSG = "Delete data fail";
        public static int FAIL_LOGIN_CODE = -1;
        public static string FAIL_LOGIN_MSG = "Login fail";

        #endregion

        #region Warning Code

        public static int WARNING_NO_DATA_CODE = 4;
        public static string WARNING_NO_DATA_MSG = "No data";
        public static int WARNING_USER_EXIST_CODE = 4;
        public static string WARNING_USER_EXIST_MSG = "User exist";
        public static int WARNING_EMAIL_EXIST_CODE = 4;
        public static string WARNING_EMAIL_EXIST_MSG = "Email exist";
        public static int WARNING_PHONE_EXIST_CODE = 4;
        public static string WARNING_PHONE_EXIST_MSG = "Phone exist";
        public static int WARNING_INVALID_PHONE_CODE = 4;
        public static string WARNING_INVALID_PHONE_MSG = "Invalid Phone";
        public static int WARNING_INVALID_EMAIL_CODE = 4;
        public static string WARNING_INVALID_EMAIL_MSG = "Invalid Email";
        public static int WARNING_INVALID_PASSWORD_CODE = 4;
        public static string WARNING_INVALID_PASSWORD_MSG = "Invalid Password";
        public static int WARNING_INVALID_USERNAME_CODE = 4;
        public static string WARNING_INVALID_USERNAME_MSG = "Invalid Username";
        public static int WARNING_USERNAME_NOT_EXIST_CODE = 4;
        public static string WARNING_USERNAME_NOT_EXIST_MSG = "Username not exist";
        public static int WARNING_WRONG_PASSWROD_CODE = 4;
        public static string WARNING_WRONG_PASSWROD_MSG = "Wrong Password";

        #endregion

    }

}
