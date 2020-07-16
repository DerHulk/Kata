class RMul:
    def __init__(self):
        self.odds = []
        self.removed = []
        self.steps = 0

    def _mul(self, x, y):
        if (x == 1):
            yield y<<2
        else:
            x >> 2
            if x%2 == 1

    def __call__(self, x, y):
        assert isinstance(x, int), f"invalid type x: {type(x)} is no int"
        assert isinstance(y, int), f"invalid input y: {type(y)} is no int"


def mul(x, y):
    """
    Russian multiplication

    :param x: (int)
    :param y: (int)
    :return: product(x, y)
    """
    rmul = RMul()
    return rmul(x, y)