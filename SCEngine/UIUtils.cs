using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SCEngine {
    public static class UIUtils {
        /// <summary>
        /// 判断一个文本是否符合模糊搜索的条件。
        /// </summary>
        /// <param name="text">要搜索的文本。</param>
        /// <param name="keyword">搜索关键词，可以包含多个单词，用空格分隔。</param>
        /// <returns>如果文本符合搜索条件，返回true；否则返回false。</returns>
        public static bool FuzzyMatch(string text, string keyword) {
            // 将搜索关键词按空格分割成单词数组
            string[] keywords = keyword.ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // 构建正则表达式模式
            string pattern = string.Join(".*", keywords);

            // 构建模糊搜索的正则表达式
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            // 检查文本是否匹配模式
            return regex.IsMatch(text.ToLower());
        }

        /// <summary>
        /// 判断一个类型对应的类有无默认构造函数
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool HasDefaultConstructor(Type type) {
            return type.GetConstructor(Type.EmptyTypes) != null;
        }

        /// <summary>
        /// 判断类是否可被反射实例化
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool CanInstantiate(Type type) {
            if (type.IsClass && !type.IsAbstract) {
                // 类是具体类，检查是否有公共的无参数构造函数
                return type.GetConstructor(Type.EmptyTypes) != null;
            }
            else if (type.IsAbstract || type.IsSealed) {
                // 类是静态类
                return false;
            }
            else {
                // 类是抽象类，检查是否有非抽象的派生类
                return Array.Exists(type.Assembly.GetTypes(), t => t.IsSubclassOf(type) && !t.IsAbstract);
            }
        }

        public static string TrimEnd(string input, string wordToRemove) {
            // 检查字符串末尾是否包含指定单词
            if (input.EndsWith(wordToRemove)) {
                // 计算截取的长度，包括空格
                int lengthToRemove = wordToRemove.Length + (input.EndsWith(" ") ? 1 : 0);

                // 截取字符串，去除末尾的单词和可能的空格
                string result = input.Substring(0, input.Length - lengthToRemove);
                return result;
            }
            return input;
        }
    }
}
