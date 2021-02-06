import os
import re

import matplotlib.pyplot as plt
import numpy as np


def format_name(name):
    result = re.sub("\s*\([^)]*\)", "", name)
    result = result.replace(" ", "_")
    result = result.lower()
    return result


def create_burndown_chart(sprint):
    fig, ax = plt.subplots()

    x = [i for i in range(sprint.days + 1)]

    # Generate actual burndown chart
    points = sprint.commitment
    actual_burndown = []
    actual_burndown.append(points)
    for day in sprint.completed:
        points -= day
        if (points < 0):
            points = 0
        actual_burndown.append(points)
    plt.plot(
        x[: len(sprint.completed) + 1],
        actual_burndown,
        color="red",
        marker="o",
        label="Remaining effort",
    )

    # Generate ideal burndown chart
    points = sprint.commitment
    ideal_burndown = []
    ideal_burndown.append(points)
    average_work = sprint.commitment / sprint.days
    for index in range(sprint.days):
        points -= average_work
        ideal_burndown.append(points)
    plt.plot(x, ideal_burndown, color="blue", marker="", label="Ideal burndown")

    plt.title(f"Burndown Chart - {sprint.name}")
    plt.xlabel("Day")
    ax.set_xticks(x)
    plt.ylabel("Story Points")
    ax.set_yticks(np.arange(0, sprint.commitment + 15, 10))
    ax.legend()
    plt.grid(True)

    name = format_name(sprint.name)
    if not os.path.exists("exported"):
        os.makedirs("exported")
    plt.savefig(f"exported/burndown_chart_{name}.png", bbox_inches="tight")

    plt.close()

    print(f"Saved burndown_chart_{name}.png")
