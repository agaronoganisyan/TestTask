# Витрина предложений с базовой бизнес логикой.
Представляет собой скроллируемый список предложений, с возможностью приобретения за N виртуальной валюты.

## Данные
Витрина может содержать следующие предложения:
+ Изображение (sprite)
+ Описание (string)
+ Изображение с описанием (sprite + string)
+ Пара изображений (sprite + sprite)
+ Пара описаний (string + string)
+ Виртуальная валюта (int)

У каждого предложения (за исключением виртуальной валюты) есть цена

## Заполнение списка
Организовать заполнение и редактирование списка через инспектор.

Допускается использовать сторонние решения для работы с инспектором

## Отображение витрины
+ Витрина может содержать неограниченное число предложений
+ Поля списка должны быть пронумерованы
+ Каждое поле должно отображать предложение, включая кнопку покупки с отображением цены. В случае, если цены нет (либо она равна нулю), отображение цены заменяется на FREE
+ Предусмотреть счетчик виртуальной валюты
+ Использовать стандартные решения Unity для работы с UI

## Бизнес логика
Пользователь пытается приобрести предложение, нажимая на кнопку покупки
+ В случае, если виртуальной валюты недостаточно, пользователь получает соответствующее сообщение
+ В случае, если виртуальной валюты достаточно, пользователь получает сообщение с подтверждением его действий
  + В случае подтверждения сообщение исчезает, исчезает предложение из списка, игрок видит изменение суммы на счетчике виртуальной валюты
  + В случае отказа сообщение исчезает
+ В случае, если цены нет (либо она равна нулю), исчезает предложение из списка, игрок видит изменение суммы на счетчике виртуальной валюты

## Запуск проекта
Версия unity 2022.3.19f1

Игра запускается с MainScene.

Для того, чтобы задать баланс и список предложений, надо на объекте сцены SceneContext внести изменения в скрипты CurrrencyModel и OffersModel.



