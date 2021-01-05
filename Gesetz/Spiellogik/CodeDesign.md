# Infos zum CodeDesign

## Code-Sprache

Der Code ist aus der Domain-Driven-Design Ecke geschrieben. Daher sind alle Namen in deutsch. 
Es gibt auch möglichst keine "technischen" Namen.
(Gutes Buch zu diesem Thema: "Patterns, Principles, and Practices of Domain-Driven Design" von Scott Millett und Nick Tune)

## Verwendete Design-Patterns

Es werden folgende Design-Patterns verwendet:
* Repository-Pattern. Die Klasse ```Spielspeicher``` ist beispielsweise ein Repository.

Man könnte mehr mit Interfaces, Dependency Injection, DI-Containern etc. arbeiten.
Das wurde erst mal nicht gemacht, damit der Code leichter verständlich ist.

Value-Objects wären auch sinnvoll, wurden aber aus demselben Grund nicht verwendet.

## Projekte

Der ganze Code zum Spiel steht in Projekt "Gesetz". Vielleicht wäre es besser, zumindest Frontend und
Backend auf zwei Projekte zu verteilen. Ich wollte es aber möglichst leicht verständlich halten.
Die Spiellogik befindet sich im Unterordner "Spiellogik". 
Unit-Tests zur Spiellogik gibt es im Projekt Gesetz.Spiellogik.UnitTests


