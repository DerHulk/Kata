from behave import *
from mulpy import mul

use_step_matcher("re")


@given("we have ([xy]) = (.+)")
def step_impl(context, xy, number):
    """
    :type context: behave.runner.Context
    :type arg0: str
    """
    setattr(context, xy, int(number))


@when("we multiply (.+) \* (.+)")
def step_impl(context, arg0, arg1):
    """
    :type context: behave.runner.Context
    :type arg0: str
    """
    x = getattr(context, arg0)
    y = getattr(context, arg1)
    context.result = mul(x, y)


@then("we expect the result == (.+)")
def step_impl(context, expected):
    """
    :type context: behave.runner.Context
    :type arg0: str
    """
    assert context.result == int(expected)