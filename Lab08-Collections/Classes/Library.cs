using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab08_Collections.Classes
{
    class Library<T> : IEnumerable
    {
        T[] inventory = new T[10];
        int count = 0;

        /// <summary>
        /// Add a new item to the Library List
        /// </summary>
        /// <param name="book">The new object that needs to be added to the list</param>
        public void Add(T book)
        {
           if (count == inventory.Length)
            {
                Array.Resize(ref inventory, inventory.Length * 2);
            }

            inventory[count++] = book;
        }

        public T Remove(T item)
        {
            int quarter = count - 1;
            int tempcount = 0;
            T[] temp;
            T removedBook = default(T);

            if (IsAvailable(item))
            {
                if(count < inventory.Length / 2)
                {
                    temp = new T[quarter];
                }
                else
                {
                    temp = new T[inventory.Length];
                }

                for (int i = 0; i < count; i++)
                {
                    if (inventory[i] != null)
                    {
                        if (!inventory[i].Equals(item))
                        {
                            temp[tempcount] = inventory[i];

                            tempcount++;
                        }
                        else
                        {
                            removedBook = inventory[i];
                        }
                    }
                }
                inventory = temp;
                count--;
            }
            
            return removedBook;
        }

        public int Count()
        {
            return count;
        }

        // Stretch goal
        /// <summary>
        /// This method checks to see if an item exists in the Library
        /// </summary>
        /// <param name="book">The book that is being searched</param>
        /// <returns>True/False indicator if the book exists in the library</returns>
        public bool IsAvailable(T book)
        {
            for (int i = 0; i < count; i++)
            {
                if (inventory[i].Equals(book))
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return inventory[i];
            }
        }

        // Magic Don't Touch

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
