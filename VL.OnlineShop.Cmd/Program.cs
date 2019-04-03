using System;
using System.Security.Principal;
using System.Threading;

namespace VL.OnlineShop.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericIdentity _identity = new GenericIdentity("");
            GenericPrincipal _principal = new GenericPrincipal(_identity, new string[] { });
            Thread.CurrentPrincipal = _principal;

            string loginName = Thread.CurrentPrincipal.Identity.Name;
            bool isLogin = Thread.CurrentPrincipal.Identity.IsAuthenticated;
            bool isAdmin = Thread.CurrentPrincipal.IsInRole("管理员");
            bool isWebUser = Thread.CurrentPrincipal.IsInRole("网站会员");
            Console.WriteLine("当前用户: {0}", loginName);
            Console.WriteLine("是否已经登录? {0}", isLogin);
            Console.WriteLine("是否管理员? {0}", isAdmin);
            Console.WriteLine("是否网站会员? {0}", isWebUser);
            Console.WriteLine("");

            _identity = new GenericIdentity("菩提树下的杨过");
            _principal = new GenericPrincipal(_identity, new string[] { "管理员", "网站会员" });
            Thread.CurrentPrincipal = _principal;
            Console.WriteLine("用户登录: {0}", Thread.CurrentPrincipal.Identity.Name);
            Console.WriteLine("");

            loginName = Thread.CurrentPrincipal.Identity.Name;
            isLogin = Thread.CurrentPrincipal.Identity.IsAuthenticated;
            isAdmin = Thread.CurrentPrincipal.IsInRole("管理员");
            isWebUser = Thread.CurrentPrincipal.IsInRole("网站会员");
            Console.WriteLine("当前用户: {0}", loginName);
            Console.WriteLine("是否已经登录? {0}", isLogin);
            Console.WriteLine("是否管理员? {0}", isAdmin);
            Console.WriteLine("是否网站会员? {0}", isWebUser);
            Console.WriteLine("");

            Console.Read();
        }
    }
}
