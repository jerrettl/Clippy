import matplotlib.pyplot as plt
import numpy as np
from sprint import Sprint


class BurndownChart:
    def __init__(self, total_points):
        self.sprints = []
        self.total_points = total_points

    def addSprint(self, name, commitment, completed):
        self.sprints.append(Sprint(name, commitment, completed))

    def makeGraph(self):
        total_sprints = 8
        fig, ax = plt.subplots()

        x = [i for i in range(total_sprints + 1)]

        # Generate actual burndown graph
        temp_points = self.total_points
        points_left = []
        points_left.append(temp_points)
        for sprint in self.sprints:
            temp_points -= sprint.completed
            points_left.append(temp_points)
        plt.plot(
            x[: len(points_left)],
            points_left,
            color="red",
            marker="o",
            label="Remaining effort",
        )

        # Generate ideal burndown graph
        temp_points = self.total_points
        points_left = []
        points_left.append(temp_points)
        average_work = self.total_points / total_sprints
        for index in range(total_sprints):
            temp_points -= average_work
            points_left.append(temp_points)
        plt.plot(x, points_left, color="blue", marker="", label="Ideal burndown")

        plt.title("Burndown Chart")
        plt.xlabel("Sprint")
        ax.set_xticks(x)
        plt.ylabel("Estimated points remaining")
        ax.set_yticks(np.arange(0, self.total_points + 15, 10))
        ax.legend()
        plt.grid(True)
        plt.savefig("exported/burndown_chart.png", bbox_inches="tight")
        plt.close()
