# Created by lauscht at 16.07.2020

Feature: Multiplication
  Some Mutlitplaction implementation as defined in the Readme.

  Scenario Outline:
    Given we have x = <x>
     Given we have y = <y>
      When we multiply x * y
     Then we expect the result == <expected>
    Examples:
    |  x |  y | expected |
    |  5 |  3 |      15  |
    | 42 | 47 |    1974  |