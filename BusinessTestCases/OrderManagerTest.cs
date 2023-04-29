using System;
using System.Reflection.Emit;
using Business.Business;
using Business.Interfaces;
using GenerateCode.Model;

namespace BusinessTestCases
{
    public class OrderManagerTest
    {
        private readonly IOrderManager _manager;

        public OrderManagerTest()
        {
            _manager = new OrderManager();
        }
        [Fact]
        public void SortTextList_ReturnsExpectedResult_ForMultipleVerticalLines()
        {
            // Arrange
            var textList = new List<TextInformation>
    {
        new TextInformation
        {
            description = "Line 1 Text 1",
            boundingPoly = new BoundingPoly
            {
                vertices = new List<Vertex>
                {
                    new Vertex { x = 10, y = 50 },
                    new Vertex { x = 10, y = 60 },
                    new Vertex { x = 20, y = 60 },
                    new Vertex { x = 20, y = 50 }
                }
            }
        },
        new TextInformation
        {
            description = "Line 2 Text 1",
            boundingPoly = new BoundingPoly
            {
                vertices = new List<Vertex>
                {
                    new Vertex { x = 30, y = 40 },
                    new Vertex { x = 30, y = 50 },
                    new Vertex { x = 40, y = 50 },
                    new Vertex { x = 40, y = 40 }
                }
            }
        },
        new TextInformation
        {
            description = "Line 1 Text 2",
            boundingPoly = new BoundingPoly
            {
                vertices = new List<Vertex>
                {
                    new Vertex { x = 15, y = 55 },
                    new Vertex { x = 15, y = 65 },
                    new Vertex { x = 25, y = 65 },
                    new Vertex { x = 25, y = 55 }
                }
            }
        },
        new TextInformation
        {
            description = "Line 2 Text 2",
            boundingPoly = new BoundingPoly
            {
                vertices = new List<Vertex>
                {
                    new Vertex { x = 35, y = 45 },
                    new Vertex { x = 35, y = 55 },
                    new Vertex { x = 45, y = 55 },
                    new Vertex { x = 45, y = 45 }
                }
            }
        }
    };
            var result = _manager.SortTextList(textList);

            Assert.Equal(1, result.Count);
            Assert.Equal(4, result[0].Count);
            Assert.Equal("Line 2 Text 1", result[0][0].description);
            Assert.Equal("Line 2 Text 2", result[0][1].description);
        }
    }
}
