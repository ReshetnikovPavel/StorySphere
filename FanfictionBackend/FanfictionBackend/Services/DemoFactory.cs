using FanfictionBackend.Dto;
using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;

// ReSharper disable StaticMemberInitializerReferesToMemberBelow

namespace FanfictionBackend.Services;

public class DemoFactory
{
    private readonly IUserService _userService;
    private readonly IFanficService _fanficService;
    
    public DemoFactory(IUserService userService, IFanficService fanficService)
    {
        _userService = userService;
        _fanficService = fanficService;
    }

    public void InitData()
    {
        InitUsers();
        InitFanfics();
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
    }

    private void InitFanfics()
    {
        _fanficService.AddFanfic(new AddFanficDto
            {
                Title = "Система баллов в вузе: все, что нужно знать",
                Fandom = "Образование",
                Characters = "Студенты, преподаватели, деканат",
                Pairings = "",
                AgeLimit = AgeLimit.G,
                Category = Category.Other,
                Genre = "Обучение, Учебная литература",
                Warnings = "Отсутствует",
                AuthorNotes = "Эта книга перечисляет основные правила системы баллов в моем университете, которые действуют в университетах России в целом. Это практический гайд, который поможет сэкономить время и избежать ненужных проблем.",
                Description = "Как работает система баллов в университетах? Как определить количество баллов за каждый предмет? Что делать, если оценка ниже проходного балла? Ответы на эти вопросы и многое другое вы найдете в этой книге.",
                IsTranslation = false
            },
            "SoftOwl");
        _fanficService.AddChapter(1, new AddChapterDto
        {
            Title = "Основные правила системы баллов",
            Content = "В этой главе вы узнаете, как работает система баллов в университетах, как определяются баллы за каждый предмет, а также какие правила действуют при пересдачах и других ситуациях."
        });
        _fanficService.AddChapter(1, new AddChapterDto
        {
            Title = "Средний балл и проходной балл",
            Content = "В этой главе вы научитесь вычислять средний балл за семестр, рассчитывать проходной балл и понимать, как он влияет на вашу успеваемость и дальнейшую учебу."
        });

        
        _fanficService.AddFanfic(new AddFanficDto
            {
                Title = "ООП на C# - это просто прекрасно!",
                Fandom = "Технологии",
                Characters = "Программисты, C#-эксперты",
                Pairings = "",
                AgeLimit = AgeLimit.G,
                Category = Category.Other,
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
        });
        _fanficService.AddChapter(2, new AddChapterDto
        {
            Title = "Основные принципы C#",
            Content = "В этой главе вы научитесь создавать классы и объекты в C#, а также узнаете об основных принципах ООП на примере этого языка программирования."
        });
        
        
        _fanficService.AddFanfic(new AddFanficDto
        {
            Title = "Rust - лучший язык программирования!",
            Fandom = "Технологии",
            Characters = "Программисты, Rust-эксперты",
            Pairings = "",
            AgeLimit = AgeLimit.G,
            Category = Category.Other,
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
        });
        _fanficService.AddChapter(3, new AddChapterDto
        {
            Title = "Основы Rust",
            Content = "В этой главе вы научитесь создавать переменные и основные типы данных в Rust, а также узнаете о ссылках и привязках на основе области видимости переменных."
        });
    }
}

