using System;
using System.Collections.Generic;

namespace NotesApp
{
    class Program
    {
        static List<Note> notes = new List<Note>();
        static int currentIndex = 0;

        static void Main(string[] args)
        {
            // Создание тестовых заметок
            notes.Add(new Note("Заметка 1", "Описание заметки 1", new DateTime(2021, 1, 1)));
            notes.Add(new Note("Заметка 2", "Описание заметки 2", new DateTime(2021, 2, 2)));
            notes.Add(new Note("Заметка 3", "Описание заметки 3", new DateTime(2021, 3, 3)));

            Console.WriteLine("Нажмите стрелку 'Вправо' или 'Влево' для переключения между заметками");
            ShowMenu();

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    NextNote();
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    PreviousNote();
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    ShowNoteDetails();
                }
            }
        }

        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Заметка: " + notes[currentIndex].Title);
        }

        static void NextNote()
        {
            currentIndex = (currentIndex + 1) % notes.Count;
            ShowMenu();
        }

        static void PreviousNote()
        {
            if (currentIndex == 0)
            {
                currentIndex = notes.Count - 1;
            }
            else
            {
                currentIndex--;
            }
            ShowMenu();
        }

        static void ShowNoteDetails()
        {
            Console.Clear();
            Note note = notes[currentIndex];
            Console.WriteLine("Заметка: " + note.Title);
            Console.WriteLine("Описание заметки: " + note.Description);
            Console.WriteLine("Дата: " + note.Date.ToString("dd.MM.yyyy"));
            Console.WriteLine("Дата выполнения: " + note.DueDate.ToString("dd.MM.yyyy"));
            Console.WriteLine("Нажмите Enter для продолжения");
            Console.ReadLine();
            ShowMenu();
        }
    }

    class Note
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }

        public Note(string title, string description, DateTime dueDate)
        {
            Title = title;
            Description = description;
            Date = DateTime.Now;
            DueDate = dueDate;
        }
    }
}