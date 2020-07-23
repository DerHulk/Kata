class RMul:
    def __init__(self):
        self.odds = []
        self.removed = []
        self.steps = 0

    def _mul(self, x, y):
        if (x % 2) == 1:
            yield y

        if x == 1:
            raise StopIteration

        x = x >> 1
        y = y << 1

        for _ in self._mul(x, y):
            yield _

    def __call__(self, x, y):
        assert isinstance(x, int), f"invalid type x: {type(x)} is no int"
        assert isinstance(y, int), f"invalid input y: {type(y)} is no int"

        sign_x = 1 if x > 0 else -1
        sign_y = 1 if y > 0 else -1
        x, y = abs(x), abs(y)
        result = sum(self._mul(x, y))

        return result if sign_x == sign_y else -result


def mul(x, y):
    """
    Russian multiplication

    :param x: (int)
    :param y: (int)
    :return: product(x, y)
    """
    rmul = RMul()
    return rmul(x, y)