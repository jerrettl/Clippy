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
    print("Creating charts...")

    sprint1_name = "Sprint 1 (1/31/2021 - 2/6/2021)"
    sprint1_completion = [0, 0, 0, 12, 0, 17, 7]
    sprint1 = Sprint(sprint1_name, days=7, commitment=30, completed=sprint1_completion)
    create_burndown_chart(sprint1)

    sprint2_name = "Sprint 2 (2/7/2021 - 2/14/2021)"
    sprint2_completion = [0, 0, 0, 3, 0, 6, 0, 37]
    sprint2 = Sprint(sprint2_name, days=8, commitment=46, completed=sprint2_completion)
    create_burndown_chart(sprint2)

    sprint3_name = "Sprint 3 (2/14/2021 - 2/21/2021)"
    sprint3_completion = [0, 0, 0, 0, 0, 11, 2, 8]
    sprint3 = Sprint(sprint3_name, days=8, commitment=43, completed=sprint3_completion)
    create_burndown_chart(sprint3)

    sprint4_name = "Sprint 4 (2/22/2021 - 2/28/2021)"
    sprint4_completion = [4, 0, 10, 10, 16, 20, 20]
    sprint4 = Sprint(sprint4_name, days=7, commitment=80, completed=sprint4_completion)
    create_burndown_chart(sprint4)

    sprint5_name = "Sprint 5 (3/1/2021 - 3/7/2021)"
    sprint5_completion = [0, 0, 0, 1, 0, 23, 25]
    sprint5 = Sprint(sprint5_name, days=7, commitment=49, completed=sprint5_completion)
    create_burndown_chart(sprint5)

    sprint6_name = "Sprint 6 (3/8/2021 - 3/14/2021)"
    sprint6_completion = [18, 34, 0, 72, 7, 0, 7]
    sprint6 = Sprint(sprint6_name, days=7, commitment=138, completed=sprint6_completion)
    create_burndown_chart(sprint6)

    sprint7_name = "Sprint 7 (3/15/2021 - 3/21/2021)"
    sprint7_completion = [22, 0, 9, 5, 18, 15, 21]
    sprint7 = Sprint(sprint7_name, days=7, commitment=90, completed=sprint7_completion)
    create_burndown_chart(sprint7)

    sprints = [sprint1, sprint2, sprint3, sprint4, sprint5, sprint6, sprint7]
    create_velocity_chart(sprints)


if __name__ == "__main__":
    main()
