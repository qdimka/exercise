# exercise
# Задание 1: проектирование БД

https://dbdesigner.net/designer/schema/84649

# Задание 2: написание SQL запросов

* Показать ТОП 10 активных пользователей
```sql
select
    u.Name as 'UserName',
    p.BlogId as 'Blog',
    count(p.Id) as 'Activity'
from Posts as p, Blogs as b, Users as u
where p.BlogId = b.Id and b.UserId = u.Id
group by p.BlogId
ORDER BY count(p.Id) desc limit 10
```

* Найти все категории, в которых есть посты пользователя А, но нет постов пользователя Б
```sql
select 
    c.Id,
    c.Title as 'Category'
from Categories as c, Blogs as b, Users as u
    left join Posts pA on pA.BlogId = b.Id and b.UserId = u.Id and u.Name = "A"    
where 
    c.id = pA.CategoryId and pA.CategoryId not in (select pB.CategoryId 
                                                   From Posts as pB, Blogs as bB, Users as uB
                                                   where pB.BlogId = bB.Id and bB.UserId = uB.Id and uB.Name = "B")
```

# Задание 3: модуль .NET
