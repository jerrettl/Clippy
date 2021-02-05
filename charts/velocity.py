import matplotlib.pyplot as plt
import numpy as np
from sprint import Sprint


class VelocityChart:
    def __init__(self):
        self.sprints = []

    def addSprint(self, name, commitment, completed):
        self.sprints.append(Sprint(name, commitment, completed))

    def makeGraph(self):
        label_locations = np.arange(len(self.sprints))
        bar_width = 0.35

        commitment_values = []
        completed_values = []
        for sprint in self.sprints:
            commitment_values.append(sprint.commitment)
            completed_values.append(sprint.completed)

        fig, ax = plt.subplots()
        commitment_bar = ax.bar(
            label_locations - bar_width / 2,
            commitment_values,
            bar_width,
            label="Comitment",
        )
        completed_bar = ax.bar(
            label_locations + bar_width / 2,
            completed_values,
            bar_width,
            label="Completed",
        )

        """ Credit to: https://matplotlib.org/3.1.1/gallery/lines_bars_and_markers/barchart.html"""

        def autolabel(rects):
            """Attach a text label above each bar in *rects*, displaying its height."""
            for rect in rects:
                height = rect.get_height()
                ax.annotate(
                    "{}".format(height),
                    xy=(rect.get_x() + rect.get_width() / 2, height),
                    xytext=(0, 3),  # 3 points vertical offset
                    textcoords="offset points",
                    ha="center",
                    va="bottom",
                )

        autolabel(commitment_bar)
        autolabel(completed_bar)

        fig.tight_layout()

        ax.set_ylabel("Scores")
        ax.set_title("Velocity Chart")
        ax.set_xticks(label_locations)
        ax.set_xticklabels([sprint.name for sprint in self.sprints])
        ax.legend()

        plt.savefig("velocity_chart.png", bbox_inches="tight")
        plt.close()