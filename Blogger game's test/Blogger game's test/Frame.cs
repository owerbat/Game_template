using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger_game_s_test
{
    class Frame
    {
        private string picture_name;
        private string blogger_phrase;
        private int phrases_count; // 1 <= fc <= 4
        private string[] user_phrases;
        private Frame[] links;
        private string voice_name;

        public Frame(string bp = "", int count = 4)
        {
            voice_name = picture_name = null;
            blogger_phrase = bp;
            phrases_count = count;
            user_phrases = new string[phrases_count];
            links = new Frame[phrases_count];
            for (int i = 0; i < phrases_count; i++)
            {
                user_phrases[i] = "";
                links[i] = null;
            }
        }

        public string get_picture()
        {
            return picture_name;
        }

        public void set_picture(string path)
        {
            picture_name = path;
        }

        public string get_blogger_phrase()
        {
            return blogger_phrase;
        }

        public void set_blogger_phrase(string phrase)
        {
            blogger_phrase = phrase;
        }

        public int get_count()
        {
            return phrases_count;
        }

        public void set_count(int count)
        {
            phrases_count = count;
        }

        public string get_phrase(int number)
        {
            if (number < 0 || number >= phrases_count)
                throw new Exception("There is no that link");
            return user_phrases[number];
        }

        public void set_phrase(string phrase, int number)
        {
            if (number < 0 || number >= phrases_count)
                throw new Exception("There is no that link");
            user_phrases[number] = phrase;
        }

        public Frame get_link(int number)
        {
            if (number < 0 || number >= phrases_count)
                throw new Exception("There is no that link");
            return links[number];
        }

        public void set_link(Frame frame, int number)
        {
            if (number < 0 || number >= phrases_count)
                throw new Exception("There is no that link");
            links[number] = frame;
        }
    }
}
