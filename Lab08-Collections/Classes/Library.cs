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
        /// This method takes a book value and adds it as a new item to the Library List.
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

        /// <summary>
        /// This method takes a book value as a parameter 
        /// and remove the item from the Library List.
        /// </summary>
        /// <param name="item">The book object that needs to be removed from the list</param>
        /// <returns>The removed book object</returns>
        public T Remove(T item)
        {
            int quarter = count - 1;
            int tempcount = 0;
            T[] temp;
            T removedBook = default(T);

            if (IsAvailable(item))
            {
                // if count is less than half, them resize the array:
                if(count < inventory.Length / 2)
                {
                    // resize the array to something much smaller and efficient:
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

        /// <summary>
        /// This method sets up a counter. 
        /// </summary>
        /// <returns>The count value</returns>
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

        /// <summary>
        /// This method is required for implementing IEnumerable.
        /// </summary>
        /// <returns>The inventory iterator value</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return inventory[i];
            }
        }

        // Magic Don't Touch
        /// <summary>
        /// This method is required for implementing IEnumerable.
        /// </summary>
        /// <returns>The value from the GetEnumerator method</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
