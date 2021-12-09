namespace StringSearching
{
    public interface ISubstringSearchingAlgorythms
    {
        /// <summary>
        /// Находит смещения всех подстрок substring в text.
        /// </summary>
        /// <param name="text">Текст, который не может быть null или empty</param>
        /// <param name="substring">Подстрока, которая не может быть null или empty</param>
        /// <returns></returns>
        int[] Search(string text, string substring);
    }
}