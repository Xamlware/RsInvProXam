using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RsInvPro.Helpers
{
    public static class Extensions
    {
        #region enum extensions


        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);

        }
        #endregion

        #region bool extensions

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static bool? IsFalse(this bool? value)
        //{
        //    return value != null && value.Equals(false);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsFalse(this bool value)
        {
            return value.Equals(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool? IsFalse(this bool? value)
        {
            return value != null && value.Equals(false);
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool? IsTrue(this bool? value)
        {
            return !value.IsFalse();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool? IsNull(this bool? value)
        {
            return value == null;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsTrue(this bool value)
        {
            return !value.IsFalse();
        }

        #endregion

        #region string extensions


        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static long ToLong(this String str)
        {
            return Convert.ToInt64(str);
        }

        public static bool DoesNotStartWith(this String str, string compStr)
        {
            return str.StartsWith(compStr).IsFalse();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="findString"></param>
        /// <returns></returns>
        public static bool DoesNotContain(this String str, string findString)
        {
            return str.Contains(findString).IsFalse();
        }


        /// <summary>
        /// Is the current string null or empty?
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this String str)
        {
            return (string.IsNullOrEmpty(str) || str.Trim().Length == 0);
        }


        /// <summary>
        /// Is the current string null or empty?
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNotNullOrEmpty(this String str)
        {
            return (!str.IsNullOrEmpty());
        }


        /// <summary>
        /// Is the current string null or empty or zero?
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNotNullEmptyOrZero(this String str)
        {
            return (!str.IsNullOrEmpty() && str.IsNotEqualTo("0"));
        }


        /// <summary>
        /// Are the string values equal
        /// </summary>
        /// <param name="str"></param>
        /// <param name="valueToCompare"></param>
        /// <returns></returns>
        public static bool IsEqualTo(this String str, string valueToCompare)
        {
            return str.Trim().Equals(valueToCompare.Trim());
        }


        /// <summary>
        /// Are the string values not equal
        /// </summary>
        /// <param name="str"></param>
        /// <param name="valueToCompare"></param>
        /// <returns></returns>
        public static bool IsNotEqualTo(this String str, string valueToCompare)
        {
            if (str.IsNullOrEmpty())
            {
                return false;
            }

            return !str.Trim().IsEqualTo(valueToCompare.Trim());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string ToYearFirstDateString(this string str, string format)
        {
            var s = string.Empty;
            var sa = new string[5];

            if (str.Contains("/"))
            {
                sa = str.Contains(" ") ? str.LeftString(' ').Split('/') : str.Split('/');
                s = string.Format("{0}{1}{2}", sa[2], sa[0].Length.Equals(1) ? "0" : "" + sa[0], sa[1].Length.Equals(1) ? "0" : "" + sa[1]);
            }

            return s;
        }

        /// <summary>
        /// Safe substring
        /// </summary>
        /// <param name="s"></param>
        /// <param name="offset"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string SafeSubstring(this string str, int startIndex, int length)
        {
            string retVal = string.Empty;

            if ((str.IsNotNullOrEmpty()))
            {
                if (startIndex >= str.Length)
                {
                    startIndex = str.Length - 1;
                }


                if (startIndex < 0)
                {
                    startIndex = 0;
                }


                if (startIndex + length > str.Length)
                {
                    length = str.Length - startIndex;
                }


                if (0 <= startIndex && startIndex < str.Length && length > 0)
                {
                    retVal = str.Substring(startIndex, length);
                }
            }

            return retVal;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="findChar"></param>
        /// <returns></returns>
        public static bool IsUpperCase(this string str, char findChar)
        {
            return ((int)findChar).Between(64, 91);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="findChar"></param>
        /// <returns></returns>
        public static bool IsLowerCase(this string str, char findChar)
        {
            return !IsUpperCase(str, findChar);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="findString"></param>
        /// <returns></returns>
        public static int RightIndexOf(this string str, string findString)
        {
            int retVal = -1;
            for (int i = str.Length - findString.Length; i >= 0; i--)
            {
                if (str.Substring(i, findString.Length).Equals(findString))
                {
                    retVal = i;
                    break;
                }
            }

            return retVal;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="c"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string InsertString(this string str, char c, string s)
        {
            return str.Insert(str.IndexOf(c), s);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="numChars"></param>
        /// <returns></returns>
        public static string LeftString(this string str, int numChars)
        {
            return str.Substring(0, numChars);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string LeftString(this string str, char c)
        {
            return str.Substring(0, str.IndexOf(c));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="numChars"></param>
        /// <returns></returns>
        public static string RightString(this string str, int numChars)
        {
            return str.Substring(str.Length - numChars, numChars);
        }


        public static string GetLeftSubStringToNumberedOccurenceFromRight(this string str, int occurence, char findChar)
        {
            var retVal = string.Empty;
            var occurs = 0;
            var index = 0;

            for (int i = str.Length; i > 0; i--)
            {
                var c = str[i - 1];
                if (((int)c).Equals((int)findChar))
                {
                    index = i;
                    occurs = ++occurs;
                }

                if (occurs.Equals(occurence))
                {
                    retVal = str.Substring(0, i - 1).Trim();
                    break;
                }
            }

            return retVal;
        }

        /// <summary>
        /// Find and return the string that exists after the nth more than
        /// occurrence of the search string is found.
        /// </summary>
        /// <param name="str">search string</param>
        /// <param name="findString">string to find</param>
        /// <param name="occurrence">occurrence number</param>
        /// <param name="wholeWord">search for whole word</param>
        /// <param name="isCaseSensitive"></param>
        /// <returns>string</returns>
        public static string GetStringAt(this String str, string findString, int? occurrence = null, bool wholeWord = true, bool isCaseSensitive = false)
        {
            return str.Substring(PerformLookup(str, findString, occurrence, wholeWord, isCaseSensitive));
        }


        /// <summary>
        /// How many time does a given char occur
        /// </summary>
        /// <param name="str"></param>
        /// <param name="findChar"></param>
        /// <returns></returns>
        public static int NumOccurences(this String str, char findChar)
        {
            return str.Count(c => c.Equals(findChar));
        }


        /// <summary>
        /// Find and return the index of the where nth occurrence of the search string is found.
        /// </summary>
        /// <param name="str">search string</param>
        /// <param name="findString">string to find</param>
        /// <param name="occurrence">occurrence number</param>
        /// <param name="wholeWord">search for whole word</param>
        /// <param name="isCaseSensitive"></param>
        /// <returns>integer</returns>
        public static int GetStringIndexOf(string str, string findString, int? occurrence = null, bool wholeWord = true, bool isCaseSensitive = false)
        {
            return PerformLookup(str, findString, occurrence, wholeWord, isCaseSensitive);
        }


        /// <summary>
        /// Perform the lookup for a given string with in a string at the nth occurrence.
        /// </summary>
        /// <param name="str">search string</param>
        /// <param name="findString">string to find</param>
        /// <param name="occurrence">occurrence number</param>
        /// <param name="wholeWord">search for whole word</param>
        /// <param name="isCaseSensitive">is the search case sensitive</param>
        /// <returns>integer index of position for given occurren</returns>
        private static int PerformLookup(string str, string findString, int? occurrence, bool wholeWord, bool isCaseSensitive)
        {
            int retVal = -1;
            int lastIndex = 0;

            str = isCaseSensitive.IsFalse() ? str.ToLower() : str;
            findString = isCaseSensitive.IsFalse() ? findString.ToLower() : findString;

            if (wholeWord)
            {
                findString = " " + findString + " ";
            }

            if (occurrence == null)
            {
                retVal = str.IndexOf(findString) + (wholeWord ? 1 : 0);
            }
            else
            {
                int pos = 0;
                int x = 0;
                string s = str;
                for (int index = 1; index <= occurrence; index++)
                {
                    x = s.IndexOf(findString) + (wholeWord ? 1 : 0);
                    if (x > 0)
                    {
                        s = s.Substring(x + (findString.Length - (wholeWord ? 2 : 0)));
                        pos += x;
                        lastIndex = index;
                    }
                    else
                    {
                        break;
                    }
                }

                retVal = pos + ((findString.Length - (wholeWord ? 2 : 0)) * lastIndex);
            }
            return retVal;
        }


        /// <summary>
        /// Replace char at
        /// </summary>
        /// <param name="str"></param>
        /// <param name="pos"></param>
        /// <param name="replacement"></param>
        /// <param name="upper"></param>
        /// <returns></returns>
        public static string ReplaceChar(this String str, int pos, string replacement, bool upper = false)
        {
            var retVal = string.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                if (i + 1 == pos)
                {
                    retVal += upper ? replacement.ToUpper() : replacement;
                }
                else
                {
                    if (str[i] != '"')
                    {
                        retVal += str[i];
                    }
                }
            }
            return retVal;
        }

        /// <summary>
        /// Replace char at
        /// </summary>
        /// <param name="str"></param>
        /// <param name="pos"></param>
        /// <param name="replacement"></param>
        /// <param name="upper"></param>
        /// <returns></returns>
        public static string RemoveChars(this String str, string charsToRemove)
        {
            var s = str;
            var retVal = string.Empty;
            foreach (var c in charsToRemove)
            {
                s = s.Replace(c.ToString(), "");
            }

            return s;
        }

        /// <summary>
        /// Remove all occurrences of specified character from given string
        /// </summary>
        /// <param name="str">string to check</param>
        /// <param name="removeChar">char to remove</param>
        /// <param name="occurrenceToStartDelete">Start At Occurrence #</param>
        /// <param name="occurrencesToDelete">Delete # occurrences including start</param>
        /// <returns>string minus char</returns>
        public static string RemoveChar(this String str, char removeChar, int? occurrenceToStartDelete = null, int? occurrencesToDelete = null)
        {
            string retVal = str;
            int? occurrenceCount = 0;
            int? maxOccurrenceCount = 0;

            if (occurrenceToStartDelete != null)
            {
                if (occurrencesToDelete != null)
                {
                    maxOccurrenceCount = (occurrenceToStartDelete + occurrencesToDelete - 1);
                    if (maxOccurrenceCount < 0)
                    {
                        maxOccurrenceCount = 0;
                    }
                }
            }


            if (str.Contains(removeChar.ToString()))
            {
                retVal = string.Empty;

                foreach (Char c in str)
                {
                    if (c.Equals(removeChar))
                    {
                        occurrenceCount++;
                        if (occurrenceToStartDelete != null)
                        {
                            if (occurrenceCount >= occurrenceToStartDelete)
                            {
                                if (maxOccurrenceCount > 0)
                                {
                                    if (occurrenceCount <= maxOccurrenceCount)
                                    {
                                        //delete the char   
                                    }
                                    else
                                    {
                                        retVal += c;
                                    }
                                }
                                else
                                {
                                    //delete the char
                                }
                            }
                            else
                            {
                                retVal += c;
                            }
                        }
                    }
                    else
                    {
                        retVal += c;
                    }
                }
            }

            return retVal;
        }

        #endregion

        #region integer extensions

        /// <summary>
        /// Are the numbers not equal?
        /// </summary>
        /// <param name="num">number</param>
        /// <param name="compare">value to compare</param>
        /// <returns>t/f</returns>
        public static bool NotEquals(this int num, int compare)
        {
            return (!num.Equals(compare));
        }


        /// <summary>
        /// is the number between start and end?
        /// </summary>
        /// <param name="num">number</param>
        /// <param name="start">start</param>
        /// <param name="end">end</param>
        /// <returns>t/f</returns>
        public static bool Between(this int num, int start, int end)
        {
            return (num >= start && num <= end);
        }


        /// <summary>
        /// Are the numbers not equal?
        /// </summary>
        /// <param name="num">number</param>
        /// <param name="compare">value to compare</param>
        /// <returns>t/f</returns>
        public static bool LessThan(this int num, int compare)
        {
            return (num < compare);
        }


        /// <summary>
        /// Are the numbers not equal?
        /// </summary>
        /// <param name="num">number</param>
        /// <param name="compare">value to compare</param>
        /// <returns>t/f</returns>
        public static bool LessThanOrEqualTo(this int num, int compare)
        {
            return (num <= compare);
        }


        /// <summary>
        /// Are the numbers not equal?
        /// </summary>
        /// <param name="num">number</param>
        /// <param name="compare">value to compare</param>
        /// <returns>t/f</returns>
        public static bool GreaterThan(this int num, int compare)
        {
            return (num > compare);
        }


        /// <summary>
        /// Are the numbers not equal?
        /// </summary>
        /// <param name="num">number</param>
        /// <param name="compare">value to compare</param>
        /// <returns>t/f</returns>
        public static bool GreaterThanOrEqualTo(this int num, int compare)
        {
            return (num >= compare);
        }


        /// <summary>
        /// Is the number equal to null
        /// </summary>
        /// <param name="num">number</param>
        /// <returns>t/f</returns>
        public static bool IsNull(this int? num)
        {
            return (num == null);
        }


        /// <summary>
        /// Is the number equal to null
        /// </summary>
        /// <param name="num">number</param>
        /// <returns>t/f</returns>
        public static bool IsNotNull(this int? num)
        {
            return (num != null);
        }




        /// <summary>
        /// Is the number equal to null
        /// </summary>
        /// <param name="num">number</param>
        /// <returns>t/f</returns>
        public static bool IsNotNullOrZero(this int? num)
        {
            return (num != null && num != 0);
        }




        /// <summary>
        /// Is the number equal to zero
        /// </summary>
        /// <param name="num">number</param>
        /// <returns>t/f</returns>
        public static bool IsZero(this int? num)
        {
            return (num != null && num.Equals(0));
        }


        /// <summary>
        /// Is the number equal to zero
        /// </summary>
        /// <param name="num"></param>
        /// <returns>t/f</returns>
        public static bool IsNullOrZero(this int? num)
        {
            return (num == null || num.Equals(0));
        }




        /// <summary>
        /// Is the number equal to zero
        /// </summary>
        /// <param name="num">number</param>
        /// <returns>t/f</returns>
        public static bool IsZero(this int num)
        {
            return (num.Equals(0));
        }

        #endregion

        #region decimal extensions

        /// <summary>
        /// Is the number equal to null
        /// </summary>
        /// <param name="num">number</param>
        /// <returns>t/f</returns>
        public static bool IsNull(this decimal? num)
        {
            return (num == null);
        }


        /// <summary>
        /// Is the number equal to zero
        /// </summary>
        /// <param name="num">number</param>
        /// <returns>t/f</returns>
        public static bool IsZero(this decimal? num)
        {
            return (num.Equals(0));
        }


        /// <summary>
        /// Is the number equal to zero
        /// </summary>
        /// <param name="num">number</param>
        /// <returns>t/f</returns>
        public static bool IsNullOrZero(this decimal? num)
        {
            return (num.Equals(0));
        }


        /// <summary>
        /// is the number equal to zero?
        /// </summary>
        /// <param name="num">number</param>
        /// <returns>t/f</returns>
        public static bool IsZero(this decimal num)
        {
            return (num.Equals(0));
        }

        #endregion

        #region double extensions

        /// <summary>
        /// Is the number equal to null
        /// </summary>
        /// <param name="num">number</param>
        /// <returns>t/f</returns>
        public static bool IsNull(this double? num)
        {
            return (num == null);
        }


        /// <summary>
        /// Is the number equal to zero
        /// </summary>
        /// <param name="num">number</param>
        /// <returns>t/f</returns>
        public static bool IsZero(this double? num)
        {
            return (num.Equals(0));
        }


        /// <summary>
        /// Is the number equal to zero
        /// </summary>
        /// <param name="num">number</param>
        /// <returns>t/f</returns>
        public static bool IsNullOrZero(this double? num)
        {
            return (num.Equals(0));
        }


        /// <summary>
        /// is the number zero?
        /// </summary>
        /// <param name="num">number</param>
        /// <returns>t/f</returns>
        public static bool IsZero(this double num)
        {
            return (num.Equals(0));
        }

        #endregion

        #region long extensions

        /// <summary>
        /// Is the number equal to null
        /// </summary>
        /// <param name="num">number</param>
        /// <returns>t/f</returns>
        public static bool IsNull(this long? num)
        {
            return (num == null);
        }



        /// <summary>
        /// Is the number equal to zero
        /// </summary>
        /// <param name="num">number</param>
        /// <returns>t/f</returns>
        public static bool IsNullOrZero(this long? num)
        {
            return (num == null || num.Equals(0));
        }


        /// <summary>
        /// is the number zero?
        /// </summary>
        /// <param name="num">number</param>
        /// <returns>t/f</returns>
        public static bool IsNotZero(this long? num)
        {
            return (num.IsNotNull() && num.Equals(0).IsFalse());
        }


        /// <summary>
        /// Is the number equal to zero
        /// </summary>
        /// <param name="num">number</param>
        /// <returns>t/f</returns>
        public static bool IsNotNullOrZero(this long? num)
        {
            return (num.IsNotNull() && num.IsNotZero());
        }
        #endregion

        #region integer extensions


        /// <summary>
        /// Are the numbers not equal?
        /// </summary>
        /// <param name="num">number</param>
        /// <param name="compare">value to compare</param>
        /// <returns>t/f</returns>
        public static bool IsNotEqualTo(this long num, long compare)
        {
            return (!num.Equals(compare));
        }


        /// <summary>
        /// is the number between start and end?
        /// </summary>
        /// <param name="num">number</param>
        /// <param name="start">start</param>
        /// <param name="end">end</param>
        /// <returns>t/f</returns>
        public static bool Between(this long num, long start, long end)
        {
            return (num >= start && num <= end);
        }


        /// <summary>
        /// Are the numbers not equal?
        /// </summary>
        /// <param name="num">number</param>
        /// <param name="compare">value to compare</param>
        /// <returns>t/f</returns>
        public static bool LessThan(this long num, long compare)
        {
            return (num < compare);
        }


        /// <summary>
        /// Are the numbers not equal?
        /// </summary>
        /// <param name="num">number</param>
        /// <param name="compare">value to compare</param>
        /// <returns>t/f</returns>
        public static bool LessThanOrEqualTo(this long num, long compare)
        {
            return (num <= compare);
        }


        /// <summary>
        /// Are the numbers not equal?
        /// </summary>
        /// <param name="num">number</param>
        /// <param name="compare">value to compare</param>
        /// <returns>t/f</returns>
        public static bool GreaterThan(this long num, long compare)
        {
            return (num > compare);
        }


        /// <summary>
        /// Are the numbers not equal?
        /// </summary>
        /// <param name="num">number</param>
        /// <param name="compare">value to compare</param>
        /// <returns>t/f</returns>
        public static bool GreaterThanOrEqualTo(this long num, long compare)
        {
            return (num >= compare);
        }


        /// <summary>
        /// Is the number equal to null
        /// </summary>
        /// <param name="num">number</param>
        /// <returns>t/f</returns>
        public static bool IsNotNull(this long? num)
        {
            return (num != null);
        }

        /// <summary>
        /// Is the number equal to zero
        /// </summary>
        /// <param name="num">number</param>
        /// <returns>t/f</returns>
        public static bool IsZero(this long num)
        {
            return (num.Equals(0L));
        }

        #endregion

        #region list extensions

        /// <summary>
        /// Is the list null
        /// </summary>
        /// <param name="num">number</param>
        /// <param name="list"></param>
        /// <returns>t/f</returns>
        public static bool IsNull<T>(this List<T> list)
        {
            return list == null;
        }


        /// <summary>
        /// Is the list not null
        /// </summary>
        /// <param name="num">number</param>
        /// <param name="list"></param>
        /// <returns>t/f</returns>
        public static bool IsNotNull<T>(this IEnumerable<T> list)
        {
            return list != null;
        }


        /// <summary>
        /// Is the ObservableCollection null
        /// </summary>
        /// <returns>t/f</returns>
        public static bool IsNull<T>(this ObservableCollection<T> collection)
        {
            return collection == null;
        }


        /// <summary>
        /// Is the ObservableCollection not null
        /// </summary>
        /// <returns>t/f</returns>
        public static bool IsNotNull<T>(this ObservableCollection<T> collection)
        {
            return collection != null;
        }

        /// <summary>
        /// Is the ObservableCollection not null
        /// </summary>
        /// <returns>t/f</returns>
        public static ObservableCollection<T> ToCollection<T>(this IEnumerable<T> source) where T : class
        {
            return new ObservableCollection<T>(source);
        }

        /// <summary>
        /// Is the ObservableCollection not null
        /// </summary>
        /// <returns>t/f</returns>
        public static bool IsEmpty<T>(this ObservableCollection<T> collection)
        {
            return collection.Any().IsFalse();
        }

        /// <summary>
        /// Is the ObservableCollection not null
        /// </summary>
        /// <returns>t/f</returns>
        public static bool IsNotEmpty<T>(this ObservableCollection<T> collection)
        {
            return collection.Any().IsTrue();
        }

        /// <summary>
        /// Is the ObservableCollection not null
        /// </summary>
        /// <returns>t/f</returns>
        public static ObservableCollection<T> ToNewCollection<T>(this IEnumerable<T> source) where T : class, new()
        {
            foreach (var s in source)
            {
                var newType = new T();
                var props = newType.GetType().GetProperties();
                foreach (var p in props)
                {

                }
            }

            return new ObservableCollection<T>(source);
        }


        /// <summary>
        /// Is the ObservableCollection not null
        /// </summary>
        /// <returns>t/f</returns>
        public static List<string> ToCommaDelimted<T>(this IEnumerable<T> source, bool header = false, string filePath = "") where T : class
        {
            var list = new List<string>();
            try
            {
                list = ProcessList(source, header);
                if (filePath.IsNotNullOrEmpty())
                {
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        foreach (var l in list)
                        {
                            writer.WriteLine(l);
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }

            return list;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        private static List<string> ProcessList<T>(IEnumerable<T> source, bool header = false)
        {
            var list = new List<string>();
            if (header.IsTrue())
            {
                list.Add(WriteHeaderLine(source.First().GetType().GetProperties()));
            }

            foreach (var s in source)
            {
                var props = s.GetType().GetProperties();
                var line = string.Empty;

                foreach (var p in props)
                {
                    line += p.GetValue(s) + ",";
                }

                list.Add(line);
            }

            return list;

        }

        private static string WriteHeaderLine(IEnumerable<PropertyInfo> props)
        {
            var line = string.Empty;
            foreach (var p in props)
            {
                line += p.Name + ", ";
            }

            return line.Substring(0, line.RightIndexOf(","));
        }


        /// <summary>
        /// Is the ObservableCollection not null
        /// </summary>
        /// <returns>t/f</returns>
        public static string ToExcel<T>(this IEnumerable<T> source) where T : class
        {
            return "";
        }



        //public static ObservableCollection<T> ToObservableCollection<T>(DataTable T)
        //{
        //    ObservableCollection<T> target = new ObservableCollection<T>();
        //    foreach (T item in source)
        //        target.Add(item);
        //    return target;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this DataTable dt) where T : class, new()
        {
            var coll = new ObservableCollection<T>();
            var colCount = dt.Columns.Count;

            foreach (DataRow row in dt.Rows)
            {

                var type = new T();
                foreach (var c in dt.Columns)
                {
                    var prop = c.ToString().RemoveChars(" /()");
                    var dataType = type.GetType().GetProperty(prop).PropertyType.FullName;

                    switch (dataType)
                    {
                        case "System.DateTime":
                            {
                                type.GetType().GetProperty(prop).SetValue(type, Convert.ToDateTime(row[c.ToString()]));
                                break;
                            }
                        case "System.Int32":
                            {
                                var value = row[c.ToString()];
                                if (value == null || value == DBNull.Value)
                                {
                                    type.GetType().GetProperty(prop).SetValue(type, row[c.ToString()]);
                                }
                                else
                                {
                                    type.GetType().GetProperty(prop).SetValue(type, Convert.ToInt32(row[c.ToString()]));
                                }
                                break;
                            }
                        case "System.Decimal":
                            {
                                var value = row[c.ToString()];
                                if (value == null || value == DBNull.Value)
                                {
                                    type.GetType().GetProperty(prop).SetValue(type, row[c.ToString()]);
                                }
                                else
                                {
                                    type.GetType().GetProperty(prop).SetValue(type, Convert.ToDecimal(row[c.ToString()]));
                                }
                                break;
                            }
                        case "System.Boolean":
                            {
                                type.GetType().GetProperty(prop).SetValue(type, row[c.ToString()]);
                                break;
                            }
                        case "System.String":
                            {
                                type.GetType().GetProperty(prop).SetValue(type, row[c.ToString()].ToString());
                                break;
                            }
                        default:
                            {
                                if (dataType.Contains("System.Nullable"))
                                {
                                    if (dataType.Contains("System.Int32"))
                                    {
                                        int number;
                                        var value = row[c.ToString()].ToString();

                                        bool result = Int32.TryParse(value, out number);
                                        if (result)
                                        {
                                            type.GetType().GetProperty(prop).SetValue(type, Convert.ToInt32(row[c.ToString()]));
                                        }
                                        else
                                        {
                                            type.GetType().GetProperty(prop).SetValue(type, null);
                                        }
                                    }
                                    else if (dataType.Contains("System.Single"))
                                    {
                                        float number;
                                        var value = row[c.ToString()].ToString();

                                        bool result = float.TryParse(value, out number);
                                        if (result)
                                        {
                                            type.GetType().GetProperty(prop).SetValue(type, Convert.ToSingle(row[c.ToString()]));
                                        }
                                        else
                                        {
                                            type.GetType().GetProperty(prop).SetValue(type, null);
                                        }
                                    }
                                    else if (dataType.Contains("System.Decimal"))
                                    {
                                        decimal number;
                                        var value = row[c.ToString()].ToString();

                                        bool result = decimal.TryParse(value, out number);
                                        if (result)
                                        {
                                            type.GetType().GetProperty(prop).SetValue(type, Convert.ToDecimal(row[c.ToString()]));
                                        }
                                        else
                                        {
                                            type.GetType().GetProperty(prop).SetValue(type, null);
                                        }
                                    }
                                }
                                break;
                            }
                    }

                }

                coll.Add(type);
            }

            return coll;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="isFirstLineHeader"></param>
        /// <param name="file"></param>
        /// <param name="splitChar"></param>
        /// <returns></returns>
        private static DataTable ToDataTable(this IEnumerable<string> file, bool isFirstLineHeader, char splitChar)
        {
            var dt = new DataTable();
            var recs = file.ToList();
            var cols = recs.Select(f => f.Split(splitChar)).Select(fArr => fArr.Count()).Concat(new[] { 0 }).Max();

            if (cols > 0)
            {

                if (isFirstLineHeader)
                {
                    foreach (var r in recs.First().Split(splitChar))
                    {
                        dt.Columns.Add(new DataColumn(r));
                    }
                }
                else
                {
                    for (int i = 0; i < cols; i++)
                    {
                        dt.Columns.Add(new DataColumn("Column" + i));
                    }
                }

            }

            return dt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isFirstLineHeader"></param>
        /// <param name="file"></param>
        /// <param name="splitChar"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(this string[] array, bool isFirstLineHeader, char splitChar)
        {
            var dt = new DataTable();

            var recs = array.ToList();
            var cols = recs.Select(f => f.Split(splitChar)).Select(fArr => fArr.Count()).Concat(new[] { 0 }).Max();

            if (cols > 0)
            {
                if (splitChar.Equals(','))
                {
                    EscapeCommasWithinStrings(recs);
                }
                if (isFirstLineHeader)
                {
                    foreach (var r in recs.First().Split(splitChar))
                    {
                        dt.Columns.Add(new DataColumn(r));
                    }
                }
                else
                {
                    for (int i = 0; i < cols; i++)
                    {
                        dt.Columns.Add(new DataColumn("Column" + i));
                    }
                }

            }

            foreach (var r in recs)
            {
                if (isFirstLineHeader)
                {
                    isFirstLineHeader = false;
                    continue;
                }
                var data = r.Split(splitChar);

                var row = dt.NewRow();
                var index = 0;
                foreach (var c in dt.Columns)
                {
                    row[index] = data[index++];
                }

                dt.Rows.Add(row);


            }

            return dt;
        }

        private static void EscapeCommasWithinStrings(List<String> data)
        {
            for (int i = 0; i < data.Count(); i++)
            {
                if (data[i].Contains("\""))
                {
                    var okay = true;
                    while (okay)
                    {
                        var d = data[i].Substring(2);
                        var start = d.IndexOf("\"");
                        var s = d.Substring(start + 1);
                        var end = s.IndexOf("\"");
                        var str = s.Substring(0, end);
                        var repString = str.Replace(",", "#%%#");
                        data[i] = data[i].Replace(str, repString);
                        //str = data[i].Substring(start+2, end+7);
                        //repString = str.Replace("\"", "");
                        //data[i] = data[i].Replace(str, repString);

                    }
                }
            }
        }




        #endregion
    }
}
