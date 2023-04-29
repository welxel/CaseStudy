using System;
using GenerateCode.Model;

namespace Business.Interfaces
{
	public interface ICodeManager
	{
	    string CodeGenerater();
	    bool InValidCode(string code);
    }
}

