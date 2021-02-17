import React, { Component } from 'react';

export class FetchStatus extends Component {
  static displayName = FetchStatus.name;

  constructor(props) {
    super(props);
    this.state = { status: '', loading: true };
  }

  componentDidMount() {
    this.populateStatus();
  }

  static renderStatus(status) {
    return (
      <p>Clippy API Status: <strong>{status}</strong></p>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchStatus.renderStatus(this.state.status);

    return (
      <div>
        <h1 id="tabelLabel" >Clippy API Status</h1>
        <p>This component fetches the status of the Clippy API.</p>
        {contents}
      </div>
    );
  }

  async populateStatus() {
    const response = await fetch('api/status');
    const data = await response.json();
    this.setState({ status: data, loading: false });
  }
}
