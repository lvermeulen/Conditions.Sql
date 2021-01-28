![Icon](https://i.imgur.com/RGy31lu.png?1)
# Conditions.Sql
[![Build status](https://ci.appveyor.com/api/projects/status/sn05aal3tj8pc9w8?svg=true)](https://ci.appveyor.com/project/lvermeulen/conditions-sql)
 [![license](https://img.shields.io/github/license/lvermeulen/Conditions.Sql.svg?maxAge=2592000)](https://github.com/lvermeulen/Conditions.Sql/blob/main/LICENSE)
 [![NuGet](https://img.shields.io/nuget/vpre/Conditions.Sql.svg?maxAge=2592000)](https://www.nuget.org/packages/Conditions.Sql/)
 ![downloads](https://img.shields.io/nuget/dt/Conditions.Sql)
 ![](https://img.shields.io/badge/.net-4.6.1-yellowgreen.svg)
 ![](https://img.shields.io/badge/netstandard-1.4-yellowgreen.svg)
 ![](https://img.shields.io/badge/netstandard-2.0-yellowgreen.svg)
 
Conditions for Dapper and SQL

## Features

This library allows you to add conditions to a SQL string. The following condition types are supported:
* Literal conditions
* Typed conditions (see below for supported operators)
* Group conditions
* Between conditions
* Not conditions

### Conditions

You can use any of the below condition types:
```csharp
string sql = "...";
sql = sql.WithCondition(new LiteralCondition("1 <> 2"));
```

### Literal conditions
```csharp
string sql = "...";
sql = sql.WithLiteralCondition("1 <> 2");
```

### Typed conditions


```csharp
string sql = "...";
sql = sql.WithTypedCondition<int>("OrderId", Operators.NotEquals, 2);
```
Operators supported are:
* =
* <>
* &lt;
* &lt;=
* &gt;
* &gt;=
* like
* in


### Group conditions
```csharp
string sql = "...";
sql = sql.WithGroupCondition(new GroupCondition(ConditionTypes.Or, new List<ICondition>
{
	new LiteralCondition("3 = 3"),
	new TypedCondition<int>("OrderId", Operators.NotEquals, 2)
}));
```

### Between conditions
```csharp
string sql = "...";
sql = sql.WithBetweenCondition("1", "0", "2");
```

### Not conditions
```csharp
string sql = "...";
sql = sql.WithNotCondition("2 <> 2");
```

## Thanks
* [condition](https://thenounproject.com/search/?q=condition&i=101727) icon by [Arthur Shlain](https://thenounproject.com/ArtZ91/) from [The Noun Project](https://thenounproject.com)
