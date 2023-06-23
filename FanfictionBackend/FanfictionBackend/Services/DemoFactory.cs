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

        _userService.RegisterUser(new RegisterDto
        {
            Username = "Demotivator_Stepan",
            Email = "stepa.zet2@gmail.com"
        }, "password");

        _userService.RegisterUser(new RegisterDto
{
Username = "0",
Email = "0@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "1",
Email = "1@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "2",
Email = "2@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "3",
Email = "3@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "4",
Email = "4@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "5",
Email = "5@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "6",
Email = "6@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "7",
Email = "7@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "8",
Email = "8@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "9",
Email = "9@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "10",
Email = "10@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "11",
Email = "11@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "12",
Email = "12@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "13",
Email = "13@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "14",
Email = "14@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "15",
Email = "15@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "16",
Email = "16@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "17",
Email = "17@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "18",
Email = "18@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "19",
Email = "19@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "20",
Email = "20@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "21",
Email = "21@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "22",
Email = "22@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "23",
Email = "23@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "24",
Email = "24@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "25",
Email = "25@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "26",
Email = "26@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "27",
Email = "27@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "28",
Email = "28@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "29",
Email = "29@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "30",
Email = "30@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "31",
Email = "31@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "32",
Email = "32@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "33",
Email = "33@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "34",
Email = "34@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "35",
Email = "35@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "36",
Email = "36@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "37",
Email = "37@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "38",
Email = "38@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "39",
Email = "39@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "40",
Email = "40@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "41",
Email = "41@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "42",
Email = "42@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "43",
Email = "43@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "44",
Email = "44@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "45",
Email = "45@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "46",
Email = "46@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "47",
Email = "47@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "48",
Email = "48@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "49",
Email = "49@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "50",
Email = "50@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "51",
Email = "51@mail.ru"
}, "password");
        _userService.RegisterUser(new RegisterDto
{
Username = "52",
Email = "52@mail.ru"
}, "password");


    }

    private void InitFanfics()
    {
        _fanficService.AddFanfic(new AddFanficDto
            {
                Title = "Система баллов в вузе: все, что нужно знать",
                Fandom = "Образование",
                Characters = "Студенты, преподаватели, деканат",
                Pairings = "Деканат/Студент",
                AgeLimit = "G",
                Category = "Другое",
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
                AgeLimit = "G",
                Category = "Другое",
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
            AgeLimit = "G",
            Category = "Другое",
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

