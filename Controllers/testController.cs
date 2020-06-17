using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]

    //public class TestsController : ControllerBase
    //{
        //[HttpGet("{Str}")]
        //public string Get(string str)
        //{
        //    char[] chararray = str.ToCharArray();
        //    for (int i = 0, j = str.Length - 1; i < j; i++, j--)
        //    {
        //        chararray[i] = str[j];
        //        chararray[j] = str[i];
        //    }
        //    string reversedString = new string(chararray);
        //    return reversedString;
        //}

        //[HttpGet("{Str}")]
        //public string Get(string str)
        //{
        //    bool pal = false;
        //    //for (int i = 0, j = str.Length - 1; i < str.Length / 2; i++, j--)
        //    for (int i = 0, j = str.Length - 1; i < str.Length / 2; i++, j--)
        //    {
        //        if (str[i] != str[j])
        //        {
        //            pal = false;
        //            break;
        //        }
        //            pal = true;
        //    }
        //    if (pal)
        //    {
        //        return "palindrom";
        //    }
        //        return "not Palindrom";
        //}

        //[HttpGet("{Str}")]
        //public string Get(string str)
        //{
        //    int i;
        //    StringBuilder reversedString = new StringBuilder();
        //    int Start = str.Length - 1;
        //    int End = str.Length - 1;
        //    while (Start > 0)
        //    {
        //        if (str[Start] == ' ')
        //        {
        //            i = Start + 1;
        //            while (i <= End)
        //            {
        //                reversedString.Append(str[i]);
        //                i++;
        //            }
        //            reversedString.Append(' ');
        //            End = Start - 1;
        //        }
        //        Start--;
        //    }
        //    for (i = 0; i <= End; i++)
        //    {
        //        reversedString.Append(str[i]);
        //    }
        //    return reversedString.ToString();
        //}

    //    [HttpGet("{Str}")]
    //    public string Get(string str)
    //    {
    //        StringBuilder reversedString = new StringBuilder();
    //        int j = 0;
    //        for (int i = 0; i < str.Length -1; i++)
    //        {
    //            if (str[i] == ' ')
    //            {

    //            }
    //        }
    //    }
    //}
}
