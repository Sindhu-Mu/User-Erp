
var pageType = { 
ResetPassword: 0,    
Login: 1,
SignUp: 2,
SignUp_S2: 3,
Home: 4
}



function GetUrl(page)
{
    switch(Number(page))
    {
        case 0:
       {
            return "../login/ResetPassword_1.aspx";
           break; 
       } 
         case 1:
       {
            return "../login/Default.aspx";
           break; 
       } 
          case 2:
       {
            return "../signup/SignUp_1.aspx";
           break; 
       } 
            case 3:
       {
            return "../signup/SignUp_2.aspx";
           break; 
       } 
       
          case 4:
       {
            return "../common/Home.aspx";
           break; 
       } 
       default:
       {
         return "javascript:void(0)";
         break;
         }
    }
}


