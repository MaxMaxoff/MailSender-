using System.Collections.Generic;
using System.Threading.Tasks;

namespace MailSender.lib.Interfaces
{
    public interface IData<TItem>
    {
        #region GetAll

        /// <summary>Получить все элементы</summary>
        /// <returns>Перечисление элементов</returns>
        IEnumerable<TItem> GetAll();

        /// <summary>Получить все элементы асинхронно</summary>
        /// <returns>Задача получения всех элементов данных</returns>
        Task<IEnumerable<TItem>> GetAllAsync();

        #endregion

        #region GetById

        /// <summary>Найти элемент по индексу</summary>
        /// <param name="id">Индекс элемента</param>
        /// <returns>Элемент в источнике данных по указанному индексу, либо null, если такой отсутствует</returns>
        TItem GetById(int id);

        /// <summary>Асинхронно найти элемент по индексу</summary>
        /// <param name="id">Индекс элемента</param>
        /// <returns>Задача поиска элемента с указанным индексом в источнике данных</returns>
        Task<TItem> GetByIdAsync(int id);

        #endregion

        #region AddNew

        /// <summary>Добавить новый элемент в источник данных</summary>
        /// <param name="NewItem">Добавляемый элемент</param>
        void AddNew(TItem NewItem);

        /// <summary>Асинхронно добавить новый элемент в источник данных</summary>
        /// <param name="NewItem">Добавляемый элемент</param>
        /// <returns>Задача асинхронного добавления нового элемента</returns>
        Task AddNewAsync(TItem NewItem);

        #endregion

        #region Delete

        /// <summary>Удалить элемент из источника данных по указанному индексу</summary>
        /// <param name="id">Индекс удаляемого элемента</param>
        void Delete(int id);

        /// <summary>Асинхронно удалить элемент с указанным индексом из источника данных</summary>
        /// <param name="id">Индекс удаляемого эелемента</param>
        /// <returns>Задача удаления элемента из источника данных</returns>
        Task DeleteAsync(int id);

        #endregion

        #region SaveChanges

        /// <summary>Сохранить изменения в источнике</summary>
        void SaveChanges();

        /// <summary>Асинхронно сохранить изменения в источнике</summary>
        /// <returns>Задача асинхронного сохранения изменений</returns>
        Task SaveChangesAsync();

        #endregion
    }
}
