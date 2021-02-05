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
        names = [sprint.name for sprint in self.sprints]

        fig, ax = plt.subplots()

        temp_points = self.total_points
        points_left = []
        for sprint in self.sprints:
            points_left.append(temp_points)
            temp_points -= sprint.completed

        x = [i for i in range(len(names))]
        plt.plot(x, points_left, color="red", marker="o")
        plt.title("Burndown Chart")
        plt.xlabel("Sprint")
        ax.set_xticks(x)
        plt.ylabel("Estimated points remaining")
        ax.set_yticks(np.arange(0, self.total_points + 15, 10))
        plt.grid(True)
        plt.savefig("exported/burndown_chart.png", bbox_inches="tight")
        plt.close()
