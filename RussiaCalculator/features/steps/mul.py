from behave import *
from mulpy import RMul

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
    context.rmul = RMul()
    context.result = context.rmul(x, y)


@then("we expect the result == (.+)")
def step_impl(context, expected):
    """
    :type context: behave.runner.Context
    :type arg0: str
    """
    assert context.result == int(expected), f"invalid resuöt {context.result} != {expected}"


@then("we expect (?P<iterations>.+) iterations")
def step_impl(context, iterations):
    """
    :type context: behave.runner.Context
    :type iterations: str
    """
    assert context.rmul.steps == int(iterations), f"invalid amount of steps {context.rmul.steps} != {iterations}"


@then("we expect (?P<even>.+) numbers")
def step_impl(context, even):
    """
    :type context: behave.runner.Context
    :type iterations: str
    """
    assert context.rmul.even == int(even), f"invalid amount of even {context.rmul.even} != {even} numbers"