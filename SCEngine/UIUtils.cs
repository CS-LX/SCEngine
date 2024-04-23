using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
