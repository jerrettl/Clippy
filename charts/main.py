from velocity import VelocityChart
from burndown import BurndownChart


class Charts:
    def __init__(self, total_points):
        self.velocity_chart = VelocityChart()
        self.burndown_chart = BurndownChart(total_points)

    def addSprint(self, name, commitment, completed):
        self.velocity_chart.addSprint(name, commitment, completed)
        self.burndown_chart.addSprint(name, commitment, completed)

    def makeGraphs(self):
        self.velocity_chart.makeGraph()
        self.burndown_chart.makeGraph()


def main():
    total_points = 100
    charts = Charts(total_points)

    charts.addSprint("Sprint1", 2, 1)
    charts.addSprint("Sprint2", 5, 5)
    charts.addSprint("Sprint3", 10, 7)
    charts.addSprint("Sprint4", 3, 3)
    charts.makeGraphs()


if __name__ == "__main__":
    main()
