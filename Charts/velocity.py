import matplotlib.pyplot as plt
import numpy as np

class VelocityChart:
	def __init__(self, sprints):
		self.sprints = sprints

	def makeGraph(self):
		label_locations = np.arange(len(self.sprints))
		barWidth = 0.35

		commitment_values = []
		completed_values = []
		for sprint in self.sprints:
			commitment_values.append(sprint.commitment)
			completed_values.append(sprint.completed)

		fig, ax = plt.subplots()
		commitment_bar = ax.bar(label_locations - barWidth / 2, commitment_values, barWidth, label = 'Comitment')
		completed_bar = ax.bar(label_locations + barWidth / 2, completed_values, barWidth, label = 'Completed')


		""" Credit to: https://matplotlib.org/3.1.1/gallery/lines_bars_and_markers/barchart.html"""
		def autolabel(rects):
		    """Attach a text label above each bar in *rects*, displaying its height."""
		    for rect in rects:
		        height = rect.get_height()
		        ax.annotate('{}'.format(height),
		                    xy=(rect.get_x() + rect.get_width() / 2, height),
		                    xytext=(0, 3),  # 3 points vertical offset
		                    textcoords="offset points",
	                   	 	ha='center', va='bottom')

		autolabel(commitment_bar)
		autolabel(completed_bar)

		fig.tight_layout()

		ax.set_ylabel('Scores')
		ax.set_title('Velocity Chart')
		ax.set_xticks(label_locations)
		ax.set_xticklabels([sprint.name for sprint in self.sprints])
		ax.legend()
		
		plt.savefig('velocity_chart.png', bbox_inches='tight')

class Sprint:
	def __init__(self, name, commitment, completed):
		self.name = name
		self.commitment = commitment
		self.completed = completed


def main():
	sprint1 = Sprint("Sprint1", 2, 1)
	velocity_chart = VelocityChart([sprint1, sprint2, sprint3])
	velocity_chart.makeGraph()

if __name__ == "__main__":
	main()
