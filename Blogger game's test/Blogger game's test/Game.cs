using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger_game_s_test
{
    abstract class Game
    {
        public const int FRAME_COUNT = 30;     //  общее количество количество мест сцен в игре (примерно)

        protected Frame first;
        protected Frame current;
        protected Frame[] frames;
        protected int score;

        public Game()
        {
            score = 0;
            frames = new Frame[FRAME_COUNT];
            build();
            first = current = frames[0];
        }

        public void move(int link_number)
        {
            current = current.get_link(link_number);
            switch (current.type_of_frame)
            {
                case Frame.frame_types.USUAL: break;
                case Frame.frame_types.FACT: score++; break;
                case Frame.frame_types.AUTOGRAPH:
                    if (score >= 5)
                    {
                        get_autograph();
                    }
                    else
                    {
                        frames[6].set_phrase("Я тебе ещё не достаточно доверяю для этого. Давай познакомимся поближе!", 0);
                    }
                    break;
                case Frame.frame_types.PHOTO:
                    if (score >= 10)
                    {
                        take_photo();
                    }
                    else
                    {
                        frames[6].set_phrase("Я тебе ещё не достаточно доверяю для этого. Давай познакомимся поближе!", 0);
                    }
                    break;
                case Frame.frame_types.SECRET:
                    if (score >= 15)
                    {
                        frames[6].set_phrase(get_random_fact().text, 0);
                        frames[6].set_voice(get_random_fact().voice_path);
                    }
                    else
                    {
                        frames[6].set_phrase("Я тебе ещё не достаточно доверяю для этого. Давай познакомимся поближе!", 0);
                    }
                    break;
                case Frame.frame_types.VIDEO:
                    if (score >= 20)
                    {
                        take_video();
                    }
                    else
                    {
                        frames[6].set_phrase("Я тебе ещё не достаточно доверяю для этого. Давай познакомимся поближе!", 0);
                    };
                    break;
                default: throw new Exception("Incorrect type of the frame");
            }
        }

        abstract protected Fact get_random_fact();
        abstract protected void get_autograph();   //   должна будет появиться анимация, может быть даже роспись, если найдём
        abstract protected void take_photo();      //   анимация
        abstract protected void take_video();      //   анимация

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

            frames[3].set_phrase("Расскажи факт о себе", 0);
            frames[3].set_phrase("<Личная просьба>", 1);
            frames[3].set_phrase("Знаешь, я тебя не люблю", 2);
            frames[3].set_phrase("Давай поговорим", 3);

            frames[4] = new Frame(get_random_fact().text, 2);
            frames[4].type_of_frame = Frame.frame_types.FACT;
            frames[4].set_phrase("Расскажи ещё", 0);
            frames[4].set_phrase("Давай поболтаем о чём-нибудь другом", 1);
            frames[4].set_link(frames[4], 0);
            frames[4].set_link(frames[3], 1);
            frames[4].set_voice(get_random_fact().voice_path); // frames[4] done

            frames[3].set_link(frames[4], 0);

            frames[5] = new Frame("О чём ты хотел(а) попросить?", 4);

            frames[5].set_phrase("Дай свой автограф", 0);
            frames[5].set_phrase("Давай сфотографируемся", 1);
            frames[5].set_phrase("Поделись со мной своей тайной", 2);
            frames[5].set_phrase("Можно сняться у тебя в видео?", 3);

            frames[6] = new Frame("", 1);
            frames[6].set_link(frames[3], 0);
        }
    }
}
