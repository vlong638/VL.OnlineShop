﻿//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.IO;
//using System.Net;
//using System.Configuration;
//using System.Web;
//using System.Security.Cryptography;

//namespace VL.OnlineShop.WebAPI.Utilities
//{
//    public class CookieHelper
//    {
//        /// <summary>
//        /// 写cookie值
//        /// </summary>
//        /// <param name="strName">名称</param>
//        /// <param name="strValue">值</param>
//        public static void WriteCookie(string strName, string strValue)
//        {
//            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
//            if (cookie == null)
//            {
//                cookie = new HttpCookie(strName);
//            }
//            cookie.Value = UrlEncode(strValue);
//            HttpContext.Current.Response.AppendCookie(cookie);
//        }

//        /// <summary>
//        /// 写cookie值
//        /// </summary>
//        /// <param name="strName">名称</param>
//        /// <param name="strValue">值</param>
//        public static void WriteCookie(string strName, string key, string strValue)
//        {
//            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
//            if (cookie == null)
//            {
//                cookie = new HttpCookie(strName);
//            }
//            cookie[key] = UrlEncode(strValue);
//            HttpContext.Current.Response.AppendCookie(cookie);
//        }

//        /// <summary>
//        /// 写cookie值
//        /// </summary>
//        /// <param name="strName">名称</param>
//        /// <param name="strValue">值</param>
//        public static void WriteCookie(string strName, string key, string strValue, int expires)
//        {
//            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
//            if (cookie == null)
//            {
//                cookie = new HttpCookie(strName);
//            }
//            cookie[key] = UrlEncode(strValue);
//            cookie.Expires = DateTime.Now.AddMinutes(expires);
//            HttpContext.Current.Response.AppendCookie(cookie);
//        }

//        /// <summary>
//        /// 写cookie值
//        /// </summary>
//        /// <param name="strName">名称</param>
//        /// <param name="strValue">值</param>
//        /// <param name="strValue">过期时间(分钟)</param>
//        public static void WriteCookie(string strName, string strValue, int expires)
//        {
//            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
//            if (cookie == null)
//            {
//                cookie = new HttpCookie(strName);
//            }
//            cookie.Value = UrlEncode(strValue);
//            cookie.Expires = DateTime.Now.AddMinutes(expires);
//            HttpContext.Current.Response.AppendCookie(cookie);
//        }

//        /// <summary>
//        /// 读cookie值
//        /// </summary>
//        /// <param name="strName">名称</param>
//        /// <returns>cookie值</returns>
//        public static string GetCookie(string strName)
//        {
//            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
//                return UrlDecode(HttpContext.Current.Request.Cookies[strName].Value.ToString());
//            return "";
//        }

//        /// <summary>
//        /// 读cookie值
//        /// </summary>
//        /// <param name="strName">名称</param>
//        /// <returns>cookie值</returns>
//        public static string GetCookie(string strName, string key)
//        {
//            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null && HttpContext.Current.Request.Cookies[strName][key] != null)
//                return UrlDecode(HttpContext.Current.Request.Cookies[strName][key].ToString());

//            return "";
//        }
//    }
//}
