using FanfictionBackend.Dto;
using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;

// ReSharper disable StaticMemberInitializerReferesToMemberBelow

namespace FanfictionBackend.Services;

public class DemoFactory
{
    private readonly IUserService _userService;
    private readonly IFanficService _fanficService;
    private readonly ILikeService _likeService;

    public DemoFactory(IUserService userService, IFanficService fanficService, ILikeService likeService)
    {
        _userService = userService;
        _fanficService = fanficService;
        _likeService = likeService;
    }

    public void InitData()
    {
        InitUsers();
        InitFanfics();
        InitLikes();
    }

    private void InitUsers()
    {
        _userService.RegisterUser(new RegisterDto
        {
            Username = "Capitulation",
            Email = "Andreydolphin@mail.ru"
        }, "password");

        _userService.RegisterUser(new RegisterDto
        {
            Username = "SoftOwl",
            Email = "anna.sok.03@mail.ru"
        }, "password");

        _userService.RegisterUser(new RegisterDto
        {
            Username = "PavelResh",
            Email = "pasha.keyzet@yandex.ru"
        }, "password");

        _userService.RegisterUser(new RegisterDto
        {
            Username = "RedSquid",
            Email = " asvjqflr2018@gmail.com"
        }, "password");

        _userService.RegisterUser(new RegisterDto
        {
            Username = "Angel_Sm",
            Email = "a@gmail.com"
        }, "password");

        _userService.RegisterUser(new RegisterDto
        {
            Username = "AnyAnya",
            Email = "b@gmail.com"
        }, "password");

        _userService.RegisterUser(new RegisterDto
        {
            Username = "Ham2681",
            Email = "c@gmail.com"
        }, "password");

        _userService.RegisterUser(new RegisterDto
        {
            Username = "OiOiOiOiiii",
            Email = "d@gmail.com"
        }, "password");

        _userService.RegisterUser(new RegisterDto
        {
            Username = "FraerMan",
            Email = "e@gmail.com"
        }, "password");

        _userService.RegisterUser(new RegisterDto
        {
            Username = "Gogi",
            Email = "f@gmail.com"
        }, "password");

                _userService.RegisterUser(new RegisterDto
        {
            Username = "Gog",
            Email = "ddd@gmail.com"
        }, "password");
                _userService.RegisterUser(new RegisterDto
        {
            Username = "ogi",
            Email = "sssf@gmail.com"
        }, "password");
                _userService.RegisterUser(new RegisterDto
        {
            Username = "Gssssogi",
            Email = "fssss@gmail.com"
        }, "password");
                _userService.RegisterUser(new RegisterDto
        {
            Username = "Gogssssssi",
            Email = "f@gmssssssssail.com"
        }, "password");
                _userService.RegisterUser(new RegisterDto
        {
            Username = "Gogssssssssi",
            Email = "f@gmaisssssssssssl.com"
        }, "password");
                _userService.RegisterUser(new RegisterDto
        {
            Username = "Gssogi",
            Email = "f@sssssssssssgmail.com"
        }, "password");
    }

    private void InitFanfics()
    {
        _fanficService.AddFanfic(new AddFanficDto
            {
                Title = "Система баллов в вузе: все, что нужно знать",
                Fandom = "Образование",
                Characters = "Студенты, преподаватели, деканат",
                Pairings = "Нет",
                AgeLimit = "G",
                Category = "Article",
                Genre = "Обучение, Учебная литература",
                Warnings = "Отсутствует",
                AuthorNotes = "Эта книга перечисляет основные правила системы баллов в моем университете, которые действуют в университетах России в целом. Это практический гайд, который поможет сэкономить время и избежать ненужных проблем.",
                Description = "Как работает система баллов в университетах? Как определить количество баллов за каждый предмет? Что делать, если оценка ниже проходного балла? Ответы на эти вопросы и многое другое вы найдете в этой книге.",
                IsTranslation = true
            },
            "SoftOwl");
        _fanficService.AddChapter(1, new AddChapterDto
        {
            Title = "Основные правила системы баллов",
            Content = "В этой главе вы узнаете, как работает система баллов в университетах, как определяются баллы за каждый предмет, а также какие правила действуют при пересдачах и других ситуациях."
        }, "SoftOwl");
        _fanficService.AddChapter(1, new AddChapterDto
        {
            Title = "Средний балл и проходной балл",
            Content = "В этой главе вы научитесь вычислять средний балл за семестр, рассчитывать проходной балл и понимать, как он влияет на вашу успеваемость и дальнейшую учебу."
        }, "SoftOwl");
        _fanficService.AddChapter(1, new AddChapterDto
        {
            Title = "Как отследить все, что у вас есть?",
            Content = "В этой главе вы научитесь создавать себе красивую табличку в экселе, в которой сможете отслеживать свои драгоценные чиселки!"
        }, "SoftOwl");
        _fanficService.AddChapter(1, new AddChapterDto
        {
            Title = "Почему автоматы - очень классная вещь?",
            Content = "Тут мы поймем, когда автомат - хорошо и здорово, а когда вы останетесь грустным школьником без стипендии и с единственной тройкой!"
        }, "SoftOwl");


        _fanficService.AddFanfic(new AddFanficDto
            {
                Title = "ООП - это просто прекрасно!",
                Fandom = "Технологии",
                Characters = "Программисты, C#-эксперты",
                Pairings = "",
                AgeLimit = "G",
                Category = "Other",
                Genre = "Обучение, Учебная литература",
                Warnings = "Отсутствует",
                AuthorNotes = "Я увлекаюсь программированием на C# уже несколько лет, и я просто обожаю ООП. Надеюсь, мой фанфик будет полезен для начинающих программистов!",
                Description = "Книга посвящена одному из самых популярных языков программирования - C#. Вы изучите основные принципы ООП на примере этого языка, а также научитесь применять их на практике.",
                IsTranslation = false
            },
            "Capitulation");
        _fanficService.AddChapter(2, new AddChapterDto
        {
            Title = "Что такое ООП?",
            Content = "В этой главе вы узнаете, что такое объектно-ориентированное программирование (ООП) и каковы его основные принципы."
        }, "Capitulation");
        _fanficService.AddChapter(2, new AddChapterDto
        {
            Title = "Основные принципы C#",
            Content = "В этой главе вы научитесь создавать классы и объекты в C#, а также узнаете об основных принципах ООП на примере этого языка программирования."
        }, "Capitulation");

        _fanficService.AddFanfic(new AddFanficDto
        {
            Title = "Rust - лучший язык программирования!",
            Fandom = "Технологии",
            Characters = "Программисты, Rust-эксперты",
            Pairings = "",
            AgeLimit = "G",
            Category = "Other",
            Genre = "Обучение, Учебная литература",
            Warnings = "Отсутствует",
            AuthorNotes = "AAAA",
            Description = "Купить книгу о программировании или начать изучать зарубежные уроки на YouTube - как выбрать правильный вариант? Книга посвящена языку программирования Rust и помогает сделать первые шаги в изучении языка.",
            IsTranslation = false
        },
            "SoftOwl");

        _fanficService.AddFanfic(new AddFanficDto
        {
            Title = "Гоги любит ооп!",
            Fandom = "Технологии",
            Characters = "Программисты",
            Pairings = "",
            AgeLimit = "PG-13",
            Category = "Article",
            Genre = "Обучение, Учебная литература",
            Warnings = "Отсутствует",
            AuthorNotes = "AAAA",
            Description = "Гоги любит ооп! Да! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит!",
            IsTranslation = false
        },
            "Gogi");

        _fanficService.AddFanfic(new AddFanficDto
        {
            Title = "Гоги любит Раст!",
            Fandom = "Технологии",
            Characters = "Программисты",
            Pairings = "",
            AgeLimit = "PG-13",
            Category = "Article",
            Genre = "Обучение, Учебная литература",
            Warnings = "Отсутствует",
            AuthorNotes = "AAAA",
            Description = "Гоги любит Раст! Да! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит!",
            IsTranslation = false
        },
            "Gogi");

        _fanficService.AddFanfic(new AddFanficDto
        {
            Title = "Гоги любит Матмех!",
            Fandom = "Технологии",
            Characters = "Программисты",
            Pairings = "",
            AgeLimit = "PG-13",
            Category = "Article",
            Genre = "Обучение, Учебная литература",
            Warnings = "Отсутствует",
            AuthorNotes = "AAAA",
            Description = "Гоги любит Матмех! Да! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит!",
            IsTranslation = false
        },
            "Gogi");

        _fanficService.AddFanfic(new AddFanficDto
        {
            Title = "Гоги любит Маму!",
            Fandom = "Технологии",
            Characters = "Программисты",
            Pairings = "",
            AgeLimit = "PG-13",
            Category = "Article",
            Genre = "Обучение, Учебная литература",
            Warnings = "Отсутствует",
            AuthorNotes = "AAAA",
            Description = "Гоги любит Маму! Да! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит!",
            IsTranslation = false
        },
            "Gogi");

        _fanficService.AddFanfic(new AddFanficDto
        {
            Title = "Гоги любит Солнышко!",
            Fandom = "Технологии",
            Characters = "Программисты",
            Pairings = "",
            AgeLimit = "PG-13",
            Category = "Article",
            Genre = "Обучение, Учебная литература",
            Warnings = "Отсутствует",
            AuthorNotes = "AAAA",
            Description = "Гоги любит Солнышко! Да! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит!",
            IsTranslation = false
        },
            "Gogi");

        _fanficService.AddFanfic(new AddFanficDto
        {
            Title = "Гоги любит Горох!",
            Fandom = "Технологии",
            Characters = "Программисты",
            Pairings = "",
            AgeLimit = "PG-13",
            Category = "Article",
            Genre = "Обучение, Учебная литература",
            Warnings = "Отсутствует",
            AuthorNotes = "AAAA",
            Description = "Гоги любит Горох! Да! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит!",
            IsTranslation = false
        },
            "Gogi");

        _fanficService.AddFanfic(new AddFanficDto
        {
            Title = "Гоги любит себя!",
            Fandom = "Технологии",
            Characters = "Программисты",
            Pairings = "",
            AgeLimit = "PG-13",
            Category = "Article",
            Genre = "Обучение, Учебная литература",
            Warnings = "Отсутствует",
            AuthorNotes = "AAAA",
            Description = "Гоги любит себя! Да! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит!",
            IsTranslation = false
        },
            "Gogi");

        _fanficService.AddFanfic(new AddFanficDto
        {
            Title = "Гоги любит Рыбок!",
            Fandom = "Технологии",
            Characters = "Программисты",
            Pairings = "",
            AgeLimit = "PG-13",
            Category = "Article",
            Genre = "Обучение, Учебная литература",
            Warnings = "Отсутствует",
            AuthorNotes = "AAAA",
            Description = "Гоги любит Рыбок! Да! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит!",
            IsTranslation = false
        },
            "Gogi");

        _fanficService.AddFanfic(new AddFanficDto
        {
            Title = "Гоги любит Стулья!",
            Fandom = "Технологии",
            Characters = "Программисты",
            Pairings = "",
            AgeLimit = "PG-13",
            Category = "Article",
            Genre = "Обучение, Учебная литература",
            Warnings = "Отсутствует",
            AuthorNotes = "AAAA",
            Description = "Гоги любит Стулья! Да! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит! Любит!",
            IsTranslation = false
        },
            "Gogi");

        _fanficService.AddFanfic(new AddFanficDto
        {
            Title = "Rust - лучший язык программирования!",
            Fandom = "Технологии",
            Characters = "Программисты, Rust-эксперты",
            Pairings = "",
            AgeLimit = "G",
            Category = "Other",
            Genre = "Обучение, Учебная литература",
            Warnings = "Отсутствует",
            AuthorNotes = "Это моя первая попытка писать фанфик о технологиях. Буду очень благодарен за отзывы!",
            Description = "Купить книгу о программировании или начать изучать зарубежные уроки на YouTube - как выбрать правильный вариант? Книга посвящена языку программирования Rust и помогает сделать первые шаги в изучении языка.",
            IsTranslation = false
        },
            "PavelResh");
        _fanficService.AddChapter(3, new AddChapterDto
        {
            Title = "Введение в Rust",
            Content = "Rust - это мощный и быстрый язык программирования, разработанный в Mozilla. В этой главе вы узнаете, что такое Rust, каковы его основные принципы и какие преимущества он предлагает по сравнению с другими языками программирования."
        }, "PavelResh");
        _fanficService.AddChapter(3, new AddChapterDto
        {
            Title = "Основы Rust",
            Content = "В этой главе вы научитесь создавать переменные и основные типы данных в Rust, а также узнаете о ссылках и привязках на основе области видимости переменных."
        }, "PavelResh");
    }
    
    private void InitLikes()
    {
        _likeService.AddLike(1, "Capitulation");
        _likeService.AddLike(1, "PavelResh");
        _likeService.AddLike(3, "Capitulation");
        _likeService.AddLike(3, "SoftOwl");
        _likeService.AddLike(2, "PavelResh");
        _likeService.AddLike(2, "SoftOwl");
        _likeService.AddLike(2, "Gogi");
    }
}
