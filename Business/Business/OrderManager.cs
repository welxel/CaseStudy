using System;
using System.Reflection.Metadata;
using System.Text;
using Business.Interfaces;
using GenerateCode.Model;
using Newtonsoft.Json;

namespace Business.Business
{
	public class OrderManager : IOrderManager
	{
        public string SolvingOrderResponse(string reponseJson)
        {
            List<TextInformation> myTextList = JsonConvert.DeserializeObject<List<TextInformation>>(reponseJson);

            var realSortedTextList = SortTextList(myTextList);

            var orderForXTextList = realSortedTextList.Select(innerlist => innerlist.OrderBy(x => x.boundingPoly.vertices[0].x)).ToList();


            StringBuilder stringBuilder = new StringBuilder();
            foreach (var sortedText in orderForXTextList)
            {
                string text = "";
                foreach (var item in sortedText)
                {
                    text = text + item.description;
                }
                text = text + "\n";
                stringBuilder.Append(text);
            }
            return stringBuilder.ToString();
        }

        public List<List<TextInformation>> SortTextList(List<TextInformation> myTextList)
        {
            List<List<TextInformation>> textArrayList = new List<List<TextInformation>>();

            var sortedList = myTextList.OrderBy(t => t.boundingPoly.vertices[2].y).ToList();

            int minyValue = sortedList[0].boundingPoly.vertices[2].y;

            List<TextInformation> textInfoList = new List<TextInformation>();

            textInfoList.Add(sortedList[0]);
            textArrayList.Add(textInfoList);

            for (int i = 1; i < sortedList.Count; i++)
            {

                if (sortedList[i].boundingPoly.vertices[2].y - minyValue < 15)
                {
                    textInfoList.Add(sortedList[i]);
                    minyValue = sortedList[i].boundingPoly.vertices[2].y;
                }
                else
                {
                    textInfoList = new List<TextInformation>();
                    textInfoList.Add(sortedList[i]);
                    minyValue = sortedList[i].boundingPoly.vertices[2].y;
                    textArrayList.Add(textInfoList);
                }

            }
            return textArrayList;
        }
    }
}

