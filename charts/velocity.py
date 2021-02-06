import os

import matplotlib.pyplot as plt
import numpy as np


def autolabel(rects, ax):
    # Credit to: https://matplotlib.org/3.1.1/gallery/lines_bars_and_markers/barchart.html
    # Attach a text label above each bar in *rects*, displaying its height.

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


def create_velocity_chart(sprints):
    label_locations = np.arange(len(sprints))
    bar_width = 0.35

    commitment_values = [s.commitment for s in sprints]
    completed_values = [s.total_completed() for s in sprints]

    fig, ax = plt.subplots()
    commitment_bar = ax.bar(
        label_locations - bar_width / 2,
        commitment_values,
        bar_width,
        label="Commitment",
    )
    completed_bar = ax.bar(
        label_locations + bar_width / 2,
        completed_values,
        bar_width,
        label="Completed",
    )

    autolabel(commitment_bar, ax)
    autolabel(completed_bar, ax)

    fig.tight_layout()

    ax.set_ylabel("Story Points")
    ax.set_title("Velocity Chart")
    ax.set_xticks(label_locations)
    ax.set_xticklabels([sprint.name for sprint in sprints])
    ax.legend()

    if not os.path.exists("exported"):
        os.makedirs("exported")
    plt.savefig("exported/velocity_chart.png", bbox_inches="tight")

    plt.close()

    print("Saved velocity_chart.png")
