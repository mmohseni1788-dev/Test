// See https://aka.ms/new-console-template for more information


using Test;

var service = new AdminService();
var adminUser = new UserContext("Mr.Gholizadeh", "Admin");
var normalUser = new UserContext("Mim.Mohseni", "User");


AuthorizationEngine.Invoke(service, "AddUser", adminUser);
AuthorizationEngine.Invoke(service, "AddUser", normalUser);


//string test = "String";
//ChangeString(ref test);
//Console.WriteLine(test);

//static void ChangeString(ref string str)
//{
//    str = "NewString";
//}
