using System;
using GenerateCode.Model;

namespace Business.Interfaces
{
	public interface IOrderManager
	{
		string SolvingOrderResponse(string reponseJson);

        List<List<TextInformation>> SortTextList(List<TextInformation> myTextList);
    }
}

