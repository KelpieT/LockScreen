using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;
namespace LockScreen
{
    public class NodePasswordCheckLua : IPasswordCheck
    {
        private PasswordIsCheck passwordIsCheckDel;

        public PasswordIsCheck passwordIsCheck { get => passwordIsCheckDel; set => passwordIsCheckDel = value; }

        public void CheckPassword(string password)
        {
            bool valid = LuaChecker(password);
            Debug.LogWarning("check complite " + valid.ToString());
            if (passwordIsCheck != null)
            {
                passwordIsCheck(valid);
            }
        }
        bool LuaChecker(string password)
        {
            string script = @"    
		
		function Check (n,m)
			return n==m
		end

		return Check (" + '"' +PlayerPrefs.GetString("Password") + '"' + "," + '"' + password + '"' + ")";

            DynValue res = Script.RunString(script);
            return res.Boolean;
        }
    }
}