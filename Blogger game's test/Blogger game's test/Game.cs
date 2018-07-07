using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger_game_s_test
{
    class Game
    {
        public const int FRAME_COUNT = 30;     //  общее количество количество мест сцен в игре (примерно)

        private Frame first;
        private Frame current;
        private Frame[] frames;

        public Game()
        {
            frames = new Frame[FRAME_COUNT];
            build();
            first = current = frames[0];
        }

        public void move(int link_number)
        {
            current = current.get_link(link_number);
        }

        public void build()
        {
            frames[0] = new Frame("Привеет!!!", 4);
            frames[0].set_phrase("Привет!", 0);
            frames[0].set_phrase("Здарова!", 1);
            frames[0].set_phrase("Ты кто?", 2);
            frames[0].set_phrase("Элли, это ты?", 3);

            frames[1] = new Frame("Я Elli Di, блоггер, etc", 1);
            frames[2] = new Frame("Ты знаешь, кто я?", 2);

            frames[0].set_link(frames[2], 0);
            frames[0].set_link(frames[2], 1);
            frames[0].set_link(frames[1], 2);
            frames[0].set_link(frames[1], 3);    //   frames[0] done

            frames[3] = new Frame("Что бы ты хотела узнать?", 4);

            frames[1].set_phrase("Понятно", 0);
            frames[1].set_link(frames[3], 0);    //   frames[1] done

            frames[2].set_phrase("Нет", 0);
            frames[2].set_phrase("Знаю", 1);

            frames[2].set_link(frames[1], 0);
            frames[2].set_link(frames[3], 1);    //   frames[2] done


        }
    }
}
