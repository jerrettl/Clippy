from burndown import create_burndown_chart
from velocity import create_velocity_chart


class Sprint:
    def __init__(self, name, days, commitment, completed):
        self.name = name
        self.days = days
        self.commitment = commitment
        self.completed = completed

    def create_charts(self):
        create_burndown_chart(self)
        create_velocity_chart(self)

    def total_completed(self):
        return sum(self.completed)


def main():
    sprint1_name = "Sprint 1 (1/31/2021 - 2/6/2021)"
    sprint1_completion = [0, 0, 0, 12, 0, 17, 7]
    sprint1 = Sprint(sprint1_name, days=7, commitment=30, completed=sprint1_completion)
    create_burndown_chart(sprint1)

    sprints = [sprint1]
    create_velocity_chart(sprints)


if __name__ == "__main__":
    main()
