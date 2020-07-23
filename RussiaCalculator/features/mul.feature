# Created by lauscht at 16.07.2020

Feature: Multiplication
  Some Mutlitplaction implementation as defined in the Readme.

  Scenario Outline: multiplication
    Given we have x = <x>
     Given we have y = <y>
      When we multiply x * y
     Then we expect the result == <expected>
    Examples:
    |  x |  y | expected |
    |  5 |  3 |      15  |
    | -7 |  3 |     -21  |
    | -7 | -5 |      35  |
    | 42 | 47 |    1974  |

  Scenario Outline: Anzahl Teilung
    Given we have x = <x>
     Given we have y = <y>
      When we multiply x * y
     Then we expect <iterations> iterations
    Examples:
    |  x |  y | iterations |
    |  5 |  3 |          3 |
    |  7 |  3 |          3 |
    | 42 | 47 |          6 |

  Scenario Outline: Anzahl gestrichene
    Given we have x = <x>
     Given we have y = <y>
      When we multiply x * y
     Then we expect <even> numbers
    Examples:
    |  x |  y | even |
    |  5 |  3 |    1 |
    |  7 |  3 |    0 |
    | 42 |  3 |    3 |