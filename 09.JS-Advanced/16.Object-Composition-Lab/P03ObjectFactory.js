function solve(input) {
    const objs = JSON.parse(input);
    const concatenate = (a, o) => ({ ...a, ...o });
    const c = objs.reduce(concatenate, {});
    return c;
}

solve(`[{"canFly": true},{"canMove":true, "doors": 4},{"capacity": 255},{"canFly":true, "canLand": true}]`);